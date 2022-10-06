﻿using HeadHunter.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HeadHunter.Importer
{
    public class VacanciesImporterActor : AbstractActor<Vacancy>
    {
        private readonly ILogger<VacanciesImporterActor> _logger;
        private readonly VacanciesImporter _importer;
        private readonly EventBus _eventBus;

        public override int ThreadCount => 20;

        public VacanciesImporterActor(ILogger<VacanciesImporterActor> logger, VacanciesImporter importer, EventBus eventBus)
        {
            _logger = logger;

            _importer = importer;
            _eventBus = eventBus;
        }

        public override async Task HandleMessage(Vacancy vacancy)
        {
            var status = await _importer.ImportVacancyAsync(vacancy);

            if (status)
            {
                _logger.LogInformation($"Successful import of vacancy: Id - {vacancy.Id} Name - {vacancy.Name} " +
                    $"Company - {vacancy.Employer.Name} Area - {vacancy.Area?.Name} PublishedAt - {vacancy.PublishedAt}");

                await _eventBus.RaiseOnVacancyImported(vacancy);
            }
            else
            {
                _logger.LogWarning($"Failed import of vacancy: Id - {vacancy.Id} Name - {vacancy.Name} " +
                    $"Company - {vacancy.Employer.Name} Area - {vacancy.Area?.Name} PublishedAt - {vacancy.PublishedAt}");
            }
        }

        public override async Task HandleError(Vacancy vacancy, Exception ex)
        {
            _logger.LogError(ex, $"Error when import vacancy: Id: {vacancy.Id} EmployerId: {vacancy.Employer.Id}");
        }
    }
}
