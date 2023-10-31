using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Inoa.Configurations
{
	public static class ConfiguracaoFabrica
    {
        public static IConfigurationRoot Criar() =>
            Criar(null);

        public static IConfigurationRoot Criar(IHostingEnvironment env) =>
            new ConfigurationBuilder()
                .SetBasePath(env != null ? env.ContentRootPath : Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
    }
}