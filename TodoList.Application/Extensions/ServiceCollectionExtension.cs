using Microsoft.Extensions.DependencyInjection;

namespace TodoList.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTodoListApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceCollectionExtension));
            return services;
        }
    }
}
