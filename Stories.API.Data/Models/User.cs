﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.API.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Vote> Vote { get; set; } = new List<Vote>();
    }
}
