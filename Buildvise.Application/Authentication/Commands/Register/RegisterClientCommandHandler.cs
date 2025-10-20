using ErrorOr;
using Buildvise.Application.Authentication.Common;
using Buildvise.Application.Common.Interfaces;
using Buildvise.Domain.Clients;
using Buildvise.Domain.Common.Interfaces;
using MediatR;

namespace Buildvise.Application.Authentication.Commands.Register;

public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, ErrorOr<ClientAuthResult>>
{
    private IJwtTokenGenerator _jwtTokenGenerator;
    private IPasswordHasher _passwordHasher;
    private IClientsRepository _clientsRepository;
    private IUnitOfWork _unitOfWork;

    public RegisterClientCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IPasswordHasher passwordHasher, 
        IClientsRepository clientsRepository, 
        IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
        _clientsRepository = clientsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<ClientAuthResult>> Handle(RegisterClientCommand command, CancellationToken cancellationToken)
    {
        if (await _clientsRepository.ExistsByEmailAsync(command.Email))
        {
            return Error.Conflict(description: "Client already exists");
        }
        
        var hashPasswordResult = _passwordHasher.HashPassword(command.Password);

        if (hashPasswordResult.IsError)
        {
            return hashPasswordResult.Errors;
        }

        var client = new Client(
            command.FullName,
            command.Email,
            command.Bio,
            hashPasswordResult.Value,
            command.PhoneNumber);
        
        await _clientsRepository.AddClientAsync(client);
        await _unitOfWork.CommitChangesAsync();
        
        var token = _jwtTokenGenerator.GenerateToken(client);

        return new ClientAuthResult(client, token);
    }
}