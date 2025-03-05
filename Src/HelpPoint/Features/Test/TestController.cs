using FluentValidation.Results;
using HelpPoint.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HelpPoint.Features.Test;

[ApiController]
[Route("api/v1/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => throw new ArgumentException("Test exception");

    [HttpGet("Valid")]
    public IActionResult GetValid()
    {
        // Simulación de errores de validación
        var failures = new List<ValidationFailure>
        {
            new ValidationFailure("Email", "El email es inválido."),
            new ValidationFailure("Password", "La contraseña debe tener al menos 8 caracteres.")
        };

        var validationResult = new ValidationResult(failures);

        throw new HelpPointValidationException(validationResult);
    }
}
