
using AutoMapper;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Crimes;
using SaveKids.Service.DTOs.CrimeCategories;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Interfaces;

namespace SaveKids.Service.Services;

public class CrimeCategoryService : ICrimeCategoryService
{
    private readonly IRepository<CrimeCategory> repository;
    private readonly IMapper mapper;

    public CrimeCategoryService(IRepository<CrimeCategory> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<CrimeCategoryResultDto> AddAsync(CrimeCategoryCreationDto dto)
    {
        var crimeCategory = mapper.Map<CrimeCategory>(dto);

        await this.repository.AddAsync(crimeCategory);
        await this.repository.SaveAsync();

        return mapper.Map<CrimeCategoryResultDto>(crimeCategory);
    }

    public async Task<CrimeCategoryResultDto> ModifyAsync(CrimeCategoryUpdateDto dto)
    {
        var existCriminalCategory = await repository.GetAsync(c => c.Id.Equals(dto.Id));

        if (existCriminalCategory is null)
            throw new NotFoundException($"This criminal category was not found with Id = {dto.Id}");

        mapper.Map(dto, existCriminalCategory);

        repository.Update(existCriminalCategory);
        await repository.SaveAsync();

        return mapper.Map<CrimeCategoryResultDto>(existCriminalCategory);
    }

    public async Task<bool> DestroyAsync(long id)
    {
        var existCriminalCategory = await repository.GetAsync(c => c.Id.Equals(id));

        if (existCriminalCategory is null)
            throw new NotFoundException($"This criminal category was not found with Id = {id}");

        this.repository.Delete(existCriminalCategory);
        await this.repository.SaveAsync();
        return true;
    }

    public async Task<CrimeCategoryResultDto> RetrieveByIdAsync(long id)
    {
        var existCriminalCategory = await repository.GetAsync(c => c.Id.Equals(id));

        if (existCriminalCategory is null)
            throw new NotFoundException($"This criminal category was not found with Id = {id}");

        return mapper.Map<CrimeCategoryResultDto>(existCriminalCategory);
    }

    public async Task<IEnumerable<CrimeCategoryResultDto>> RetrieveAllAsync(PaginationParams pagination)
    {
        var criminalCategories = repository.GetAll();

        return mapper.Map<IEnumerable<CrimeCategoryResultDto>>(criminalCategories);
    }
}
