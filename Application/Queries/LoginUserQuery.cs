using Application.Responses;
using MediatR;

namespace Application.Queries;
public class LoginUserQuery : IRequest<UserResponse>
{
    public string? Email { get; set; }
    public string? Password { get; set; }

    public LoginUserQuery(string? email,string? password)
    {
        Email = email;
        Password = password;
    }
    public LoginUserQuery()
    {
        Email = "";
        Password = "";
    }

}