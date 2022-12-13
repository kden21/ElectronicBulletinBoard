using AutoMapper;
using ElectronicBoard.AppServices.User.Repositories;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Contracts.User.Dto;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.User.Services;

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
    public async Task<UserDto> GetUserById(int userId, CancellationToken cancellation)
    {
        
        var userEntity = await _userRepository.GetUserEntityById(userId, cancellation);
        return _mapper.Map<UserDto>(userEntity);
    }

    /// <inheritdoc />
    public async Task<UserDto> CreateUser(UserDto userDto, CancellationToken cancellation)
    {
        var userEntity = _mapper.Map<UserEntity>(userDto);
        var id = await _userRepository.AddUserEntity(userEntity, cancellation);
        userDto.Id = id;
        return userDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<UserDto>> GetFilterUsers(UserFilterRequest? userFilter, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserDto>>(await _userRepository.GetFilterUserEntities(userFilter, cancellation));
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<UserDto>> GetAllUsers(CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserDto>>(await _userRepository.GetAllUserEntities(cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteUser(int userId, CancellationToken cancellation)
    {
        await _userRepository.DeleteUserEntity(userId, cancellation);
    }
    
    /// <inheritdoc />
    public async Task SoftDeleteUser(int userId, CancellationToken cancellation)
    { 
        
        await _userRepository.SoftDeleteUserEntity(userId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateUser(int userId, UserDto userDto, CancellationToken cancellation)
    {
        userDto.Id = userId;
        var user = _mapper.Map<UserEntity>(userDto);
        user.Id = userId;
        await _userRepository.UpdateUserEntity(user, cancellation);
    }
}