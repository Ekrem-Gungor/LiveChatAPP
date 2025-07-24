﻿using DevBudy.APPLICATION.Features.Auths.Dtos.Response;
using DevBudy.DOMAIN.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Auths.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserName);
            SignInResult result = await _signInManager.PasswordSignInAsync(user, request.Password.ToString(), true, true);
            if (!result.Succeeded) throw new UnauthorizedAccessException("Invalid username or password.");

            // Refactor : İleride JWT token oluşturma işlemi eklenecek.

            LoginResponseDto loginResponseDto = new() { UserId = user.Id };

            return loginResponseDto;
        }
    }
}
