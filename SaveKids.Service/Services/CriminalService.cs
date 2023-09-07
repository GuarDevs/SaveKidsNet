using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Criminals;
using SaveKids.Service.DTOs.Criminals;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Extensions;
using SaveKids.Service.Interfaces;

namespace SaveKids.Service.Services;

public class CriminalService : ICriminalService
{
    private readonly IMapper mapper;
    private readonly IRepository<Criminal> criminalRepository;
    public CriminalService(IMapper mapper, IRepository<Criminal> criminalRepository)
    {
        this.mapper = mapper;
        this.criminalRepository = criminalRepository;
    }

    public async Task<CriminalResultDto> AddAsync(CriminalCreationDto dto)
    {
        dto.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
        var criminal = await this.criminalRepository.GetAsync(c =>
                           c.FirstName.Equals(dto.FirstName)
                        && c.LastName.Equals(dto.LastName)
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
}