using Scalar.AspNetCore;
using SupportHub.Api.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationDbContext(builder.Configuration)
    .AddIdentityServices()
    .AddJwtAuthentication(builder.Configuration)
    .AddOpenApiDocumentation();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("SupportHub API")
            .WithTheme(ScalarTheme.DeepSpace)
            .WithDefaultHttpClient(ScalarTarget.Shell, ScalarClient.Curl);
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
