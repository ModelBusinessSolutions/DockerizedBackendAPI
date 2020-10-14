using App.Web.API.Interfaces;
using App.Web.API.Models;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using System;

namespace App.Web.API.Infrastructure
{
    public class MapsterProfile : IMapsterProfile
    {
        private IWebHostEnvironment _env;
        public MapsterProfile(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void Configure()
        {
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

            TypeAdapterConfig<Exception, ApiException>
            .NewConfig()
            .Map(dest => dest.Message, src => src.Message)
            .Map(dest => dest.Detail, src => src.StackTrace);
        }
    }
}