namespace PartIV.Api.Win.Models {
    public class AppSettings {
        public AppSettingsAuth Auth { get; set; } = new AppSettingsAuth();
    }
    public class AppSettingsAuth {
        public string ApiUrl { get; set; } = string.Empty;
        public string ApiKeyPublic { get; set; } = string.Empty;
        public string ApiKeyPrivate { get; set; } = string.Empty;
        public string ApiKeySignature { get; set; } = string.Empty;
    }
}