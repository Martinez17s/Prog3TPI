
using Application.DTOs;
using Application.DTOs.Requests;


namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserRequest user);

        Task<UserDto> GetUserByIdAsync(int id);

        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> UpdateAsync(UpdateUserRequest request, int id);

        Task DeleteAsync(int id);
    }
}
