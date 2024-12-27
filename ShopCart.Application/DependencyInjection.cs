using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ShopCart.Application.Commands;
using ShopCart.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddScoped<IValidator<AddItemCommand>, AddItemValidator>();

            return services;

        }
    }
}
