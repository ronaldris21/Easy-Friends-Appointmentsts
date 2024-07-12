using Summary.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Core.Services.Abstraction
{
    public interface IAppointmentService
    {
        Task<ICollection<AppointmentItemsDTO>> GetAll();
        Task<AppointmentDTO> Add(AppointmentDTO appointment);
    }
}
