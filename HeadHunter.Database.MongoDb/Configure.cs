﻿using FluentValidation;
using HeadHunter.Database.MongoDb.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.Database.MongoDb
{
    public static class Configure
    {
        public static void AddMongoDb(this IServiceCollection services)
        {
            var assembly = typeof(Configure).Assembly;
            var mongoDbContext = new MongoDbContext();

            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<Repository>();

            services.AddSingleton(mongoDbContext.GetDatabase("headHunterDB"));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }

    }
}
