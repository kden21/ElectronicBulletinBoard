using AutoMapper;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Services.User;

/// <inheritdoc />
public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    /// <inheritdoc />
    public async Task<UserDto> GetUserById(int userId)
    {
        var userEntity = await _userRepository.GetUserEntityById(userId);
        return _mapper.Map<UserDto>(userEntity);
    }

    /// <inheritdoc />
    public async Task<UserDto> CreateUser(UserDto userDto)
    {
        var userEntity = _mapper.Map<UserEntity>(userDto);
        var id = await _userRepository.AddUserEntity(userEntity);
        userDto.Id = id;
        return userDto;
    }

    /// <inheritdoc />
    public IEnumerable<UserDto> GetAllUsers()
    {
        return _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserDto>>(_userRepository.GetAllUserEntities());
    }

    /// <inheritdoc />
    public async Task DeleteUser(int userId)
    {
        await _userRepository.DeleteUserEntity(userId);
    }

    /// <inheritdoc />
    public async Task UpdateUser(int userId, UserDto userDto)
    {
        userDto.Id = userId;
        var user = _mapper.Map<UserEntity>(userDto);
        await _userRepository.UpdateUserEntity(user);
    }
}