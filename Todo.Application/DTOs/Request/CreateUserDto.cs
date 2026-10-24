using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Application.DTOs.Request
{
    public record CreateUserDto(string Email, string Fullname, string Password); // validation
}
