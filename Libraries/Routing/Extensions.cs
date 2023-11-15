using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Libraries.Routing;

public static class Extensions
{
    public static void AddApiVersioningRouting(this IServiceCollection services)
    {
        services.AddApiVersioning();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;

            var queryStringApiVersionReader = new QueryStringApiVersionReader("Query-String-Version");
            var headerApiVersionReader = new HeaderApiVersionReader("Api-Version");
            options.ApiVersionReader = ApiVersionReader.Combine(headerApiVersionReader, queryStringApiVersionReader);
        });
    }
}