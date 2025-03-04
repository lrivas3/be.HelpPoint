using HelpPoint.Config;
using HelpPoint.Core.Common;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationDbContext(builder.Configuration)
    .AddJwtAuthentication(builder.Configuration)
    .AddOpenApiDocumentation();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddControllers();

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
 {
     options.AddPolicy("AllowConfiguredOrigins", policy =>
     {
         policy.WithOrigins(allowedOrigins ?? throw new InvalidOperationException("Cors no configurado"))
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
     });
 });

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
app.UseCors("AllowConfiguredOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
