using Buildvise.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Buildvise.Application.Authentication.Commands.Register;

public record RegisterClientCommand(
    string FullName,
    string Email,
    string Bio,
    string? PhoneNumber,
    string Password) : IRequest<ErrorOr<ClientAuthResult>>;