using AutoMapper;
using VisualFXVault.Domain.DTOs;
using VisualFXVault.Domain.Entities;

namespace VisualFXVault.Domain.Mappers;

public class ApplicationUserToUserResponseMappingProfile : Profile
{
    public ApplicationUserToUserResponseMappingProfile()
    {
        CreateMap<ApplicationUser, UserResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
    }
}