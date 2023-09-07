
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
        var existCrimeCategory = await repository.GetAsync(c => c.Name.ToLower().Equals(dto.Name.ToLower()));
        if (existCrimeCategory is not null)
            throw new AlreadyExistException($"This category already exist with {dto.Name}");

        var crimeCategory = mapper.Map<CrimeCategory>(dto);

        await this.repository.AddAsync(crimeCategory);
        await this.repository.SaveAsync();

        return mapper.Map<CrimeCategoryResultDto>(crimeCategory);
    }

    public async Task<CrimeCategoryResultDto> ModifyAsync(CrimeCategoryUpdateDto dto)
    {
        var existCriminalCategory = await repository.GetAsync(c => c.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This criminal category was not found with Id = {dto.Id}");

        if(!string.Equals(existCriminalCategory.Name, dto.Name, StringComparison.OrdinalIgnoreCase))
        {
            var existCrimeCategory2 = await repository.GetAsync(c => c.Name.ToLower().Equals(dto.Name.ToLower()));
            if (existCrimeCategory2 is not null)
                throw new AlreadyExistException($"This category already exist with {dto.Name}");
        }

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

        this.repository.Destroy(existCriminalCategory);
        await this.repository.SaveAsync();
        return true;
    }

    public async Task<CrimeCategoryResultDto> RetrieveByIdAsync(long id)
    {
        var existCriminalCategory = await repository.GetAsync(c => c.Id.Equals(id), includes: new[] { "Crimes" });

        if (existCriminalCategory is null)
            throw new NotFoundException($"This criminal category was not found with Id = {id}");

        return mapper.Map<CrimeCategoryResultDto>(existCriminalCategory);
    }

    public async Task<IEnumerable<CrimeCategoryResultDto>> RetrieveAllAsync()
    {
        var criminalCategories = repository.GetAll(includes: new[] { "Crimes" });

        return mapper.Map<IEnumerable<CrimeCategoryResultDto>>(criminalCategories);
    }
}
