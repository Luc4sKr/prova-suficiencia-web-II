using Domain.DTOs;

namespace Domain.Abstractions
{
    public interface IAuthService
    {
        Task<string> Register(CreateUserRequest request);
        Task<string> Login(LoginRequest request);
    }
}
