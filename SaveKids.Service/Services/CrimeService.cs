using AutoMapper;
using SaveKids.DAL.IRepositories;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Extensions;
using SaveKids.Service.Interfaces;
using SaveKids.Service.DTOs.Crimes;
using Microsoft.EntityFrameworkCore;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Crimes;
using SaveKids.Domain.Entities.Criminals;

namespace SaveKids.Service.Services;

public class CrimeService : ICrimeService
{
    private readonly IMapper mapper;
    private readonly IRepository<Crime> crimeRepository;
    private readonly IRepository<Criminal> criminalRepository;
    private readonly IRepository<CrimeCategory> crimeCategoryRepository;

    public CrimeService(IMapper mapper, 
        IRepository<Crime> crimeRepository, 
        IRepository<Criminal> criminalRepository, 
        IRepository<CrimeCategory> crimeCategoryRepository)
    {
        this.mapper = mapper;
        this.crimeRepository = crimeRepository;
        this.criminalRepository = criminalRepository;
        this.crimeCategoryRepository = crimeCategoryRepository;
    }

    public async Task<CrimeResultDto> AddAsync(CrimeCreationDto dto)
    {
        var criminal = await this.criminalRepository.GetAsync(c => c.Id.Equals(dto.CriminalId));
        if (criminal is null)
            throw new NotFoundException("This criminal is not found");

        var crimeCategory = await this.crimeCategoryRepository
                            .GetAsync(c => c.Id.Equals(dto.CriminalCategoryId));
        if (crimeCategory is null)
            throw new NotFoundException("This crime category is not found");

        var mappedCrime = this.mapper.Map<Crime>(dto);

        mappedCrime.CriminalId = criminal.Id;
        mappedCrime.CrimeCategoryId = crimeCategory.Id;
        await this.crimeRepository.AddAsync(mappedCrime);
        await this.crimeRepository.SaveAsync();

        mappedCrime.Criminal = criminal;
        mappedCrime.CrimeCategory = crimeCategory;
        return this.mapper.Map<CrimeResultDto>(mappedCrime);
    }

    public async Task<CrimeResultDto> ModifyAsync(CrimeUpdateDto dto)
    {
        var crime = await this.crimeRepository.GetAsync(c => c.Id.Equals(dto.Id));
        if (crime is null)
            throw new NotFoundException("This crime is not found");

        var criminal = await this.criminalRepository.GetAsync(c => c.Id.Equals(dto.CriminalId));
        if (criminal is null)
            throw new NotFoundException("This criminal is not found");

        var crimeCategory = await this.crimeCategoryRepository
                            .GetAsync(c => c.Id.Equals(dto.CriminalCategoryId));
        if (crimeCategory is null)
            throw new NotFoundException("This crime category is not found");

        var mappedCrime = this.mapper.Map(dto, crime);

        mappedCrime.CriminalId = criminal.Id;
        mappedCrime.CrimeCategoryId = crimeCategory.Id;
        this.crimeRepository.Update(mappedCrime);

        mappedCrime.Criminal = criminal;
        mappedCrime.CrimeCategory = crimeCategory;
        await this.crimeRepository.SaveAsync();

        return this.mapper.Map<CrimeResultDto>(mappedCrime);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var crime = await this.crimeRepository.GetAsync(c => c.Id.Equals(id));
        if (crime is null)
            throw new NotFoundException("This crime is not found");

        this.crimeRepository.Delete(crime);
        await this.crimeRepository.SaveAsync();
        return true;
    }

    public async Task<bool> DestroyAsync(long id)
    {
        var crime = await this.crimeRepository.GetAsync(c => c.Id.Equals(id));
        if (crime is null)
            throw new NotFoundException("This crime is not found");

        this.crimeRepository.Destroy(crime);
        await this.crimeRepository.SaveAsync();
        return true;
    }

    public async Task<CrimeResultDto> RetrieveByIdAsync(long id)
    {
        var crime = await this.crimeRepository.GetAsync(c => c.Id.Equals(id), includes: new[] { "Criminal", "CrimeCategory" });
        if (crime is null)
            throw new NotFoundException("This crime is not found");

        return this.mapper.Map<CrimeResultDto>(crime);
    }

    public async Task<IEnumerable<CrimeResultDto>> RetrieveAllAsync(PaginationParams pagination)
    {
        var crimes = await this.crimeRepository.GetAll(includes: new[] { "Criminal", "CrimeCategory" }).ToPaginate(pagination).ToListAsync();
        var result = this.mapper.Map<IEnumerable<CrimeResultDto>>(crimes);
        return result;
    }
}