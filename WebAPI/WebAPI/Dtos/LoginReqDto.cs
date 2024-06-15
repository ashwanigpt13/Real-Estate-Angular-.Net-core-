using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class LoginReqDto
    {
        public required string UserName {get; set;}

        public required string Password {get; set;}
    }
}