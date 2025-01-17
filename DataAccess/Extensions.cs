﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppContext>(x =>
            {
                x.UseNpgsql("Host=localhost;Database=NoteDb;Username=postgres;Password=1234");
            });
            return serviceCollection;
        }
    }
}
