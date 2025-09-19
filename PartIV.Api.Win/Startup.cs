using PartIV.Api.Win.Models;
using PartIV.Api.Win.Services;

namespace PartIV.Api.Win {
    public class Startup : IHostedService {
        public readonly IHostApplicationLifetime Lifetime;
        public readonly IConfiguration Configuration;
        public readonly IHttpClientFactory ClientFactory;
        public readonly IServiceProvider? ServiceProvider;

        private AppSettings AppSettings;

        private ApiService? apiService;

        public Startup(
            IHostApplicationLifetime lifetime, 
            IConfiguration configuration, 
            IHttpClientFactory clientFactory) {
            Lifetime = lifetime;
            Configuration = configuration;
            ClientFactory = clientFactory;

            AppSettings = Configuration.GetRequiredSection("AppSettings").Get<AppSettings>() ?? new AppSettings();  
        }

        public async Task StartAsync(CancellationToken cancellationToken) {
            apiService = new ApiService(AppSettings);

            await apiService.GetBusiness();

            Lifetime.StopApplication();
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken stoppingToken) {
            Lifetime.StopApplication();
            await Task.CompletedTask;
        }
    }

}