using DevBudy.APPLICATION.Features.Auths.Dtos.Response;
using DevBudy.DOMAIN.Entities.Concretes;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.APPLICATION.Features.Auths.Queries
{
    public class ConnectedUsersQueryHandler : IRequestHandler<ConnectedUsersQuery, List<ConnectedUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        public ConnectedUsersQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ConnectedUserDto>> Handle(ConnectedUsersQuery request, CancellationToken cancellationToken)
        {
            List<ConnectedUserDto> connectedUsers = await _userManager.Users
                .Select(user => new ConnectedUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName, // Assuming UserName is the display name
                    IsOnline = user.IsOnline
                }).ToListAsync();
            return connectedUsers;
        }
    }
}
