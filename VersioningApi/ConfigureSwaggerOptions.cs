using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VersioningApi
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider apiDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiDescriptionProvider)
        {
            this.apiDescriptionProvider = apiDescriptionProvider;
        }
        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in apiDescriptionProvider.ApiVersionDescriptions) 
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }
        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description) 
        {
            var info = new OpenApiInfo
            {
                Title = "Your versioned Api",
                Version = description.ApiVersion.ToString()
            };
            return info;
        }
    }
}
