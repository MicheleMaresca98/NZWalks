using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;


namespace Web_API_Versioning.API
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            this.apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }
        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {

            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        private Microsoft.OpenApi.Models.OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Countries API",
                Version = description.ApiVersion.ToString(),
                Description = "An ASP.NET Core Web API for managing countries",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Michele Maresca",
                    Email = "michele.maresca1998@gmail.com",
                }
            };

            return info;
        }
    }
}
    
