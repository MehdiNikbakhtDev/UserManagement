using Application.Responses;
using MediatR;

namespace Application.Queries;
public class GetUserByEmailQuery : IRequest<List<UserResponse>>
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}