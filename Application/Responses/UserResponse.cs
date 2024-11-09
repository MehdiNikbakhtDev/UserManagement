using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Responses;
public class UserResponse
{
    public long? Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public int? Status { get; set; }
    public string? RunGuid { get; set; }
    public bool? IsHauptUser { get; set; }
    public DateTime? InsertionDateTime { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
}
