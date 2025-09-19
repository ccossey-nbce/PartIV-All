using PartIV.Api.Win;

#if DEBUG
var builder = WebApplication.CreateBuilder(new WebApplicationOptions {
    EnvironmentName = Environments.Development
});
#else
var builder = WebApplication.CreateBuilder(new WebApplicationOptions {
        EnvironmentName = Environments.Production
    });
#endif

builder.Services.AddHttpClient();
builder.Services.AddHostedService<Startup>();

// -------------------------------------------------------------------------------------------------

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

try {
    app.Run();
}
catch (System.Threading.Tasks.TaskCanceledException) {
    // so what...we know the task is going to cancel..we told it to
}
catch (Exception) {
    throw;
}
