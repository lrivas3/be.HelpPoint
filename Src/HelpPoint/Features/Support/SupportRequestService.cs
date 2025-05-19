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

    public async Task<SupportRequestResponse> UpdateSupportRequestAsync(SupportRequestUpdateRequest request, Guid id)
    {
        var existingRequest = await supportRequestRepository.GetByIdAsync(id) ??
                               throw new NotFoundException("Solicitud de soporte no encontrada");

        mapper.Map(request, existingRequest);
        await supportRequestRepository.UpdateAsync(existingRequest);
        var response = mapper.Map<SupportRequestResponse>(existingRequest);
        return response;
    }

    public async Task<SupportRequestResponse> GetSupportRequestAsync(Guid requestId)
    {
        var supportRequest = await supportRequestRepository.GetByIdAsync(requestId) ??
                             throw new NotFoundException("No se encontro la solicitud de soporte");

        var response = mapper.Map<SupportRequestResponse>(supportRequest);

        return response;
    }

    public async Task<List<SupportRequestResponse>> ListSupportRequestsAsync()
    {
        var supRequests = await supportRequestRepository.GetAllPendingAsync();
        var response = mapper.Map<List<SupportRequestResponse>>(supRequests);
        return response;
    }

    public async Task<bool> DeleteSupportRequestAsync(Guid requestId)
    {
        var existingRequest = await supportRequestRepository.GetByIdAsync(requestId) ??
                            throw new NotFoundException("No se encontró la solicitud");
        await supportRequestRepository.DeleteAsync(existingRequest);
        return true;
    }
}
