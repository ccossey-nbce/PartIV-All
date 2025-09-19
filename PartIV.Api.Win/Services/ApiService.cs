using Data.TimeTap.API.Controllers;

using PartIV.Api.Win.Models;

using api = Data.TimeTap.API.Controllers.Api;

namespace PartIV.Api.Win.Services {
    public class ApiService {

        private AppSettings AppSettings;

        api Api { get; set; }
        ApiController ApiController { get; set; }

        public ApiService(AppSettings prmAppSettings) {
            AppSettings = prmAppSettings;

            Api = new api(AppSettings.Auth.ApiUrl, AppSettings.Auth.ApiKeyPublic, AppSettings.Auth.ApiKeyPrivate, AppSettings.Auth.ApiKeySignature);
            ApiController = new ApiController(Api);
        }

        public async Task GetBusiness() {
            await Task.Run(() => {
                string json = ApiController.GetBusiness();
            });
        } 
    }
}
