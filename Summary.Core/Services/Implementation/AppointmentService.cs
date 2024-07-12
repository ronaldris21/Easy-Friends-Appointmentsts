using Microsoft.EntityFrameworkCore;
using Summary.Core.Abstraction;
using Summary.Core.DTO;
using Summary.Core.Services.Abstraction;
using Summary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summary.Core.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDbContext _dbContext;
        public AppointmentService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AppointmentDTO> Add(AppointmentDTO appoinment)
        {
            if (appoinment == null) return null;

            var newAppointmentResult =  _dbContext.Appointment.Add(new Domain.Models.Appointment
            {
                Title = appoinment.Title,
                Description = appoinment.Description,
                EndDate = appoinment.EndDate,
                StartDate = appoinment.StartDate,
                Location = appoinment.Location,
                
            });

            await _dbContext.SaveChangeAsync();

            return new AppointmentDTO
            {
                Title = newAppointmentResult.Entity.Title,
                Description = newAppointmentResult.Entity.Description,
                EndDate = newAppointmentResult.Entity.EndDate,
                StartDate = newAppointmentResult.Entity.StartDate,
                Location = newAppointmentResult.Entity.Location,
            };
        }

        public async Task<ICollection<AppointmentItemsDTO>> GetAll()
        {
            return await _dbContext.Appointment
                    .Include(a => a.Friends)
                    .Select(appoinment => new AppointmentItemsDTO
                    {
                        AppointmentId = appoinment.AppointmentId,
                        Title = appoinment.Title,
                        Description = appoinment.Description,
                        EndDate = appoinment.EndDate,
                        StartDate = appoinment.StartDate,
                        Location = appoinment.Location,
                        Friends = appoinment.Friends.Select(f => new FriendDTO()
                        {
                            Name = f.Name,
                            AppointmentId = f.AppointmentId
                        }).ToList()

                    }).ToListAsync();


        }
    }
}
