using Auth;
using Carter;
using JiraTaskManager;
using SlackChat;
using Shared.Exceptions.Handler;
using Shared.Extensions;
using Shared.Services;
using Catalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddResendClient(builder.Configuration);
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type =>
    {
        return type.Namespace?.Replace("SlackChat.", "SC.")
           .Replace("JiraTaskManager.", "JTM.") + "." + type.Name;
    });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddScoped<IUploadFileService, UploadFileSevice>();

var authAssembly = typeof(AuthModule).Assembly;
var jiraAssembly = typeof(JiraTaskManagerModule).Assembly;
var slackAssembly = typeof(SlackChatModule).Assembly;

builder.Services
    .AddAuthModule(builder.Configuration)
    .AddJiraTaskManagerModule(builder.Configuration)
    .AddSlackChatModule(builder.Configuration)
    .AddEshopCatalogModule(builder.Configuration);

builder.Services.AddMediatRWithAssemblies(
    authAssembly,
    jiraAssembly,
    slackAssembly);
builder.Services.AddCarterAssemblies(
    authAssembly,
    jiraAssembly,
    slackAssembly);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(options => { });
app.UseStaticFiles();
app.UseAuthModule()
    .UseJiraTaskManagerModule()
    .UseSlackChatModule()
    .UseEshopCatalogModule();

app.UseSlackChatHub();

// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
app.MapCarter();
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
