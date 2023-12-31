﻿using SaveKids.Domain.Configurations;
using SaveKids.Service.DTOs.Crimes;
using SaveKids.Service.DTOs.Criminals;

namespace SaveKids.Service.Interfaces;

public interface ICrimeService
{
    Task<CrimeResultDto> AddAsync(CrimeCreationDto dto);
    Task<CrimeResultDto> ModifyAsync(CrimeUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<bool> DestroyAsync(long id);
    Task<CrimeResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CrimeResultDto>> RetrieveAllAsync(PaginationParams pagination);
    Task<IEnumerable<CrimeResultDto>> SearchByDescriptionAsync(string description, PaginationParams paginationParams);
}