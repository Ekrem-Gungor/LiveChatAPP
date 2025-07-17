//using LiveChatAPI.Hubs;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevBudy.DEPENDENCYRESOLVER.Bootstrappers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

string CORSPath = builder.Configuration["UICORSPath"];

#region azureEnv
string AzureCORSPath = Environment.GetEnvironmentVariable("AzureUICORSPath");
if (AzureCORSPath != null) CORSPath = AzureCORSPath;
#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins(CORSPath); // React UI portu
    });
});

// Autofac DI Container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// AutoFac modüllerini yükleme
builder.Host.ConfigureContainer<ContainerBuilder>(Bootstrapper.ConfigureServices);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

//app.MapHub<ChatHub>("/chatHub");

app.Run();
