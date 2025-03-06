using HelpPoint.Common.DependencyInjection;
using HelpPoint.Common.RequestPipeline;
using HelpPoint.Infrastructure.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddFeaturesDependencyInjection()
    .AddRepositories()
    .AddApplicationDbContext(builder.Configuration)
    .AddJwtAuthentication(builder.Configuration)
    .AddOpenApiDocumentation();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddControllers();

// builder.Services.AddSingleton<ProblemDetailsFactory, HelpPointProblemDetailsFactory>();

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

app.UseGlobalErrorHandling();

app.UseCustomOpenApiViewer();

app.UseHttpsRedirection();
app.UseCors("AllowConfiguredOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
