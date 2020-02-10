using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PositivoCore.Application.Mapper;

namespace PositivoCore.WebApi.Helpers
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            var config = AutoMapperConfig.RegisterMapper();

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
