using AutoMapper;
using EducationApp.Core.DTOs;
using EducationApp.Core.Entities;

namespace EducationApp.Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GroupDto, Group>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<RoomDto,Room>().ReverseMap();
        CreateMap<PaymentDto, Payment>().ReverseMap();
        CreateMap<StudentDto, Student>().ReverseMap();
        CreateMap<StaffDto , Staff>().ReverseMap();
    }
}