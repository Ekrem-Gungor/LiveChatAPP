﻿using DevBudy.APPLICATION.Features.Auths.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Services
{
    public interface IJwtService
    {
        /// <summary>
        /// Bu metot, verilen kullanıcı kimliğine göre JWT token oluşturur.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Oluşturulan JWT jetonunu temsil eden bir Dto verir</returns>
        Task<TokenResponseDto> GenerateToken(string userId);
    }
}
