using AutoMapper;
using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Features.Employees;
using HelpPoint.Infrastructure.Dtos.Request;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Support;

namespace HelpPoint.Features.Support;

public class SupportRequestService(
    ISupportRequestRepository supportRequestRepository,
    IEmployeeRepository employeeRepository,
    IMapper mapper)
    : ISupport
{

    public async Task<SupportRequestResponse> CreateSupportRequestAsync(SupportRequestRequest request)
    {
        var empleado = await employeeRepository.GetByEmailAsync(request.Email) ??
                       throw new NotFoundException("Empleado no encontrado con correo: " + request.Email);
        request.EmpleadoId = empleado.Id;
        var nuevaRequest = mapper.Map<SupportRequest>(request);
        var nuevaSolicitud = await supportRequestRepository.CreateSupportRequestAsync(nuevaRequest);
        var response = mapper.Map<SupportRequestResponse>(nuevaSolicitud);
        return response;
    }

    public Task<SupportRequestResponse> UpdateSupportRequestAsync(SupportRequestRequest request) => throw new NotImplementedException();

    public Task<SupportRequestResponse> GetSupportRequestAsync(Guid requestId) => throw new NotImplementedException();

    public Task<SupportRequestResponse> DeleteSupportRequestAsync(Guid requestId) => throw new NotImplementedException();
}
