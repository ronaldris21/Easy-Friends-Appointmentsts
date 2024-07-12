using Microsoft.AspNetCore.Mvc;
using Summary.Core.DTO;
using Summary.Core.Services.Abstraction;

namespace Summary.Controllers.v2
{
    [ApiVersion("2.0")]
    public class AppointmentController : ApiControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ICollection<AppointmentItemsDTO>), 200)]
        [ProducesResponseType(typeof(ICollection<AppointmentItemsDTO>), 400)]
        [ProducesResponseType(typeof(ICollection<AppointmentItemsDTO>), 401)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await appointmentService.GetAll());
        }


        [HttpPost("[action]")]
        [ProducesResponseType(typeof(AppointmentDTO), 200)]
        //[ProducesResponseType(400)]
        public async Task<IActionResult> Add(AppointmentDTO appoinment)
        {
            try
            {
                var appointmentNew = await appointmentService.Add(appoinment);

                if(appointmentNew == null)
                {
                    return BadRequest();
                }


                return Ok(appointmentNew);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

    }
}
