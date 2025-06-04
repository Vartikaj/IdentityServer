using Duende.IdentityServer.Test;
using IdentityServer;
using IdentityServer.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients) // Registers clients that are allowed to connect to IdentityServer to request tokens.
    .AddInMemoryIdentityResources(Config.IdentityResources) // Registers identity resources for OpenID Connect.
    .AddInMemoryApiResources(Config.ApiResources) // Registers API resources – these are APIs protected by IdentityServer that clients can access using access tokens.
    .AddInMemoryApiScopes(Config.ApiScopes)
    //.AddTestUsers(Config.TestUser)
    .AddDeveloperSigningCredential()// Adds a temporary signing key used by IdentityServer to sign tokens (JWTs, etc.).
    .AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>()
    .AddProfileService<ProfileService>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseIdentityServer();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello world");
    });
});

app.Run();
