using System;
using System.Collections.Generic;
using System.Text;
using Todo.Application.DTOs.Request;

namespace Todo.Application.Contracts
{
    public interface ITokenService
    {
        Task<TokenResponseDto> GetTokenAsync(TokenRequestDto requestDto);
    }
}
