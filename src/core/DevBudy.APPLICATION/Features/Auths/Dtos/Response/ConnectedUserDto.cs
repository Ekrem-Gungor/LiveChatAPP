﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Auths.Dtos.Response
{
    public class ConnectedUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsOnline { get; set; }
    }
}
