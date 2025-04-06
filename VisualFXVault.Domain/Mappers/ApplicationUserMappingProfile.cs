using AutoMapper;
using VisualFXVault.Domain.DTOs;
using VisualFXVault.Domain.Entities;

namespace VisualFXVault.Domain.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.IsSuccessful, opt => opt.Ignore());
    }
}