using HelpPoint.Infrastructure.Dtos.Response;

namespace HelpPoint.Features.Catalogo;

public interface ICatalogoService
{
    public Task<List<PSelectableResponse>> GetEstados();
} 