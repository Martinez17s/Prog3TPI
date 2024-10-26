using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateAsync(CreateUserRequest request)
        {
            var user = new User();

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Role = request.Role;
            user.UserName = request.UserName;

            _ = await _userRepository.CreateAsync(user);

            var dto = new UserDto();
            dto.Id = user.Id;
            dto.Name = user.Name;
            dto.Password = user.Password;
            dto.Email = user.Email;
            dto.UserName = user.UserName;
            dto.Role = user.Role;

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            if (result == null)
                throw new Exception("User not found");
            
            var userDto = new UserDto();
            userDto.Id = result.Id;
            userDto.Name = result.Name;
            userDto.Email = result.Email;
            userDto.UserName = result.UserName;

            return userDto;
        }

        public async Task<List<UserDto>> GetAllAsync()
        { 
            var result = await _userRepository.GetAllAsync();
            var resultDto = new List<UserDto>();
            foreach (var item in result)
            {
                var userDto = new UserDto()
                {   
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    UserName = item.UserName,
                    Role = item.Role,
                };
                resultDto.Add(userDto);
            }
            return resultDto;
        }

        public async Task<UserDto> UpdateAsync(UpdateUserRequest request, int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");

            user.Name = request.Name;
            user.Email = request.Email;
            user.UserName = request.UserName;
            user.Password = request.Password;
            user.Role = request.Role;

            await _userRepository.UpdateAsync(user);

            var dto = new UserDto();
            dto.Id = user.Id;
            dto.Name = user.Name;
            dto.Email = user.Email;
            dto.UserName = user.UserName;
            dto.Role = user.Role;

            return dto;
        }

    }
}
