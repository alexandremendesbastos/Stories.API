using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Service.DTOs
{
    public class UserDTO(int id, string name)
    {
        public int Id { get; set; } = id;
        public string UserName { get; set; } = name;
    }
}