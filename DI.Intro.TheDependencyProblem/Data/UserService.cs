namespace TheDependencyProblem.Data;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        // Do stuff here
        var users = await _userRepository.GetAllAsync();
        // Do stuff here
        return users;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        // Do stuff here
        var user = await _userRepository.GetByIdAsync(id);
        // Do stuff here
        return user;
    }

    public async Task<bool> CreateAsync(User user)
    {
        // Do stuff here
        var created = await _userRepository.CreateAsync(user);
        // Do stuff here
        return created;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        // Do stuff here
        var deleted = await _userRepository.DeleteByIdAsync(id);
        // Do stuff here
        return deleted;
    }
}
