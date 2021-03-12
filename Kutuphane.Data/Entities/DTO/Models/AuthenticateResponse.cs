using Kutuphane.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kutuphane.Data.Entities.DTO.Models
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Member user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.Username;
            Token = token;
        }
    }
}
