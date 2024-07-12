using Summary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Core.DTO
{
    public class AppointmentItemsDTO : AppointmentDTO
    {
        public ICollection<FriendDTO> Friends { get; set; }
    }
}
