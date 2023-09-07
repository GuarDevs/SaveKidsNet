using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Criminals;
using SaveKids.Service.DTOs.Attachments;
using SaveKids.Service.DTOs.Criminals;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Extensions;
using SaveKids.Service.Interfaces;

namespace SaveKids.Service.Services;

public class CriminalService : ICriminalService
{
    private readonly IMapper mapper;
    private readonly IAttachmentService attachmentService;
    private readonly IRepository<Criminal> criminalRepository;
    public CriminalService(IMapper mapper, IRepository<Criminal> criminalRepository, IAttachmentService attachmentService)
    {
        this.mapper = mapper;
        this.criminalRepository = criminalRepository;
        this.attachmentService = attachmentService;
    }

    public async Task<CriminalResultDto> AddAsync(CriminalCreationDto dto)
    {
        dto.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
        var criminal = await this.criminalRepository.GetAsync(c =>
                           c.FirstName.ToLower().Equals(dto.FirstName.ToLower())
                        && c.LastName.ToLower().Equals(dto.LastName.ToLower())
                        && c.DateOfBirth.Equals(dto.DateOfBirth));

        if (criminal is not null)
            throw new AlreadyExistException("This criminal is alredy exist");

        var mappedCriminal = this.mapper.Map<Criminal>(dto);
        await this.criminalRepository.AddAsync(mappedCriminal);
        await this.criminalRepository.SaveAsync();

        return this.mapper.Map<CriminalResultDto>(mappedCriminal);
    }

    public async Task<CriminalResultDto> ModifyAsync(CriminalUpdateDto dto)
    {
        var criminal = await this.criminalRepository.GetAsync(c => c.Id.Equals(dto.Id));
        if (criminal is null)
            throw new NotFoundException("This criminal is not found");

        dto.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
        if (!(criminal.FirstName.ToLower().Equals(dto.FirstName.ToLower())
                && criminal.LastName.ToLower().Equals(dto.LastName.ToLower())
                && criminal.DateOfBirth.Equals(dto.DateOfBirth)))
        {
            var existCriminal = await this.criminalRepository.GetAsync(c =>
                   c.FirstName.ToLower().Equals(dto.FirstName.ToLower())
                && c.LastName.ToLower().Equals(dto.LastName.ToLower())
                && c.DateOfBirth.Equals(dto.DateOfBirth));

            if (existCriminal is not null)
                throw new AlreadyExistException("This criminal is alredy exist");
        }

        var mappedCriminal = this.mapper.Map(dto, criminal);
        this.criminalRepository.Update(mappedCriminal);
        await this.criminalRepository.SaveAsync();

        return this.mapper.Map<CriminalResultDto>(mappedCriminal);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var criminal = await this.criminalRepository.GetAsync(c => c.Id.Equals(id));
        if (criminal is null)
            throw new NotFoundException("This criminal is not found");

        this.criminalRepository.Delete(criminal);
        await this.criminalRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DestroyAsync(long id)
    {
        var criminal = await this.criminalRepository.GetAsync(c => c.Id.Equals(id));
        if (criminal is null)
            throw new NotFoundException("This criminal is not found");

        this.criminalRepository.Destroy(criminal);
        await this.criminalRepository.SaveAsync();

        return true;
    }

    public async Task<CriminalResultDto> RetrieveByIdAsync(long id)
    {
        var criminal = await this.criminalRepository.GetAsync(c => c.Id.Equals(id), includes: new[] { "Crimes" });
        if (criminal is null)
            throw new NotFoundException("This criminal is not found");

        return this.mapper.Map<CriminalResultDto>(criminal);
    }

    public async Task<IEnumerable<CriminalResultDto>> RetrieveAllAsync(PaginationParams pagination)
    {
        var criminals = await this.criminalRepository.GetAll(includes: new[] { "Crimes" }).ToPaginate(pagination).ToListAsync();
        var result = this.mapper.Map<IEnumerable<CriminalResultDto>>(criminals);
        return result;
    }

    public async Task<CriminalResultDto> UploadImageAsync(long criminalId, AttachmentCreationDto dto)
    {
        var existCriminal = await criminalRepository.GetAsync(u => u.Id.Equals(criminalId))
            ?? throw new NotFoundException("This criminal not found");

        var result = await attachmentService.UploadAsync(dto);

        existCriminal.Attachment = result;
        existCriminal.AttachmentId = result.Id;

        criminalRepository.Update(existCriminal);
        await criminalRepository.SaveAsync();
        return mapper.Map<CriminalResultDto>(existCriminal);
    }

    public async Task<CriminalResultDto> ModifyImageAsync(long criminalId, AttachmentCreationDto dto)
    {
        var criminal = await this.criminalRepository.GetAsync(p => p.Id.Equals(criminalId))
            ?? throw new NotFoundException("This criminal is not found");

        await this.attachmentService.RemoveAsync(criminal.Attachment);
        var createdAttachment = await this.attachmentService.UploadAsync(dto);

        criminal.AttachmentId = createdAttachment.Id;
        criminal.Attachment = createdAttachment;
        this.criminalRepository.Update(criminal);
        await this.criminalRepository.SaveAsync();

        return this.mapper.Map<CriminalResultDto>(criminal);
    }
}