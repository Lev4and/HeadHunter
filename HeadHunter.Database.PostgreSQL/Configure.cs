﻿using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HeadHunter.Database.PostgreSQL
{
    public static class Configure
    {
        public static void AddPostgreSQL(this IServiceCollection services)
        {
            var assembly = typeof(Configure).Assembly;

            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);

            services.AddDbContext<HeadHunterDbContext>((options) =>
            {
                options.UseNpgsql("Server=lev4and.ru;Database=HeadHunter;User Id=postgres;Password=sa;" +
                    "Integrated Security=true;Pooling=true;");
            });
        }
    }
}
