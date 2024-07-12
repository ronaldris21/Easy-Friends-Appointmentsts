using Summary.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Core.Services.Abstraction
{
    public interface IFriendService
    {
        Task<ICollection<FriendDTO>> GetAll();
        Task<FriendDTO> Add(FriendDTO friend);
    }
}
