using Futbolchi_10052023_.DTOs.Identity;

namespace Futbolchi_10052023_.Servives.Identity
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDto dto);

        Task<string> CreateToken();
    }
}
