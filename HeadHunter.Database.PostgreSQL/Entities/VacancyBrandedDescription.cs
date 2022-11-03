﻿namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyBrandedDescription
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public string BrandedDescription { get; set; }

        public virtual Vacancy? Vacancy { get; set; }
    }
}
