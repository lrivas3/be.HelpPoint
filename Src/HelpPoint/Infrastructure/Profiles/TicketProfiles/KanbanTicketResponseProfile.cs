using AutoMapper;
using HelpPoint.Infrastructure.Dtos.Response;
using HelpPoint.Infrastructure.Models.Ticket;

namespace HelpPoint.Infrastructure.Profiles.TicketProfiles;

public class KanbanTicketResponseProfile : Profile
{
    public KanbanTicketResponseProfile()
    {
        CreateMap<Ticket, KanbanTicketResponse>()
            .ForMember(dest => dest.Id, 
                opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Description,
                opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.StateCode,
                opt => opt.MapFrom(src => src.EstadoId))
            .ForMember(dest => dest.TipoId,
                opt => opt.MapFrom(src => src.TipoId))
            .ForMember(dest => dest.PriorityCode,
                opt => opt.MapFrom(src => src.PrioridadId))
            .ForMember(dest => dest.CreationDate,
                opt => opt.MapFrom(src => src.FechaCreacion))
            .ForMember(dest => dest.ClosureDate,
                opt => opt.MapFrom(src => src.FechaCierre))
            .ForMember(dest => dest.OrderInBoard,
                opt => opt.MapFrom(src => src.OrdenEnTablero ?? 0))
            .ForMember(dest => dest.Tags,
                opt => opt.MapFrom(src => new List<string>()))
            .ForMember(dest => dest.Avatars,
                opt => opt.MapFrom(src => new List<string>()));
    }
} 