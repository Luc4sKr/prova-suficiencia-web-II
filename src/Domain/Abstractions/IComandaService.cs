using Domain.DTOs;
using Domain.Models;

namespace Domain.Abstractions
{
    public interface IComandaService
    {
        Task<List<ComandaSummaryResponse>> Get();
        Task<ComandaResponse?> GetById(int id);
        Task<ComandaResponse> CreateAsync(ComandaRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
