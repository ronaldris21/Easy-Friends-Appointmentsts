using Microsoft.EntityFrameworkCore;
using Summary.Core.Abstraction;
using Summary.Core.DTO;
using Summary.Core.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Core.Services.Implementation
{
    public class FriendService : IFriendService
    {
        private readonly IDbContext _dbContext;
        public FriendService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FriendDTO> Add(FriendDTO friend)
        {
            if (friend == null) return null;

            var newFriend = _dbContext.Friend.Add(new Domain.Models.Friend
                            {
                                Name = friend.Name,
                                AppointmentId = friend.AppointmentId
                            });

            friend.FriendId = newFriend.Entity.FriendId;

            await _dbContext.SaveChangeAsync();
            return friend;

        }

        public async Task<ICollection<FriendDTO>> GetAll()
        {
            return await _dbContext.Friend.Select(f => new FriendDTO
            {
                AppointmentId = f.AppointmentId,
                FriendId = f.FriendId,
                Name = f.Name
            }).ToListAsync();


        }
    }
}
