using AutoMapper;
using SaveKids.Domain.Entities.Attachments;
using SaveKids.Domain.Entities.Crimes;
using SaveKids.Domain.Entities.Criminals;
using SaveKids.Domain.Entities.Users;
using SaveKids.Service.DTOs.Attachments;
using SaveKids.Service.DTOs.CrimeCategories;
using SaveKids.Service.DTOs.Crimes;
using SaveKids.Service.DTOs.Criminals;
using SaveKids.Service.DTOs.Users;

namespace SaveKids.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<CrimeCategory, CrimeCategoryCreationDto>().ReverseMap();
        CreateMap<CrimeCategory, CrimeCategoryUpdateDto>().ReverseMap();
        CreateMap<CrimeCategory, CrimeCategoryResultDto>().ReverseMap();

        CreateMap<Crime, CrimeCreationDto>().ReverseMap();
        CreateMap<Crime, CrimeUpdateDto>().ReverseMap();
        CreateMap<Crime, CrimeResultDto>().ReverseMap();

        CreateMap<Criminal, CriminalCreationDto>().ReverseMap();
        CreateMap<Criminal, CriminalUpdateDto>().ReverseMap();
        CreateMap<Criminal, CriminalResultDto>().ReverseMap();


        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();

        CreateMap<Attachment, AttachmentCreationDto>().ReverseMap();
    }
}
