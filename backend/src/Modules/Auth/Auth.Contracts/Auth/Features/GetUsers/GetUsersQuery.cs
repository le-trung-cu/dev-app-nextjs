using Auth.Contracts.Auth.Dtos;
using Shared.CQRS;

namespace Auth.Contracts.Auth.Features.GetUsers;

public record GetUsersQuery(IEnumerable<string> UserIds) : IQuery<GetUsersResult>;

public record GetUsersResult(IEnumerable<UserItemDto> Users);