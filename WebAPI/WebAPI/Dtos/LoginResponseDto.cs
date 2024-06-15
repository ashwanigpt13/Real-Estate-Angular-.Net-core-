using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class LoginResponseDto
    {
        public required string UserName {get;set;}
        public required string Token {get;set;}
    }
}