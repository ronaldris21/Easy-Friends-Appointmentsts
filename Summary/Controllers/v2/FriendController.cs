using Microsoft.AspNetCore.Mvc;
using Summary.Core.DTO;
using Summary.Core.Services.Abstraction;

namespace Summary.Controllers.v2
{
    [ApiVersion("2.0")]
    public class FriendController : ApiControllerBase
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            this.friendService = friendService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ICollection<FriendDTO>), 200)]
        [ProducesResponseType(typeof(ICollection<FriendDTO>), 400)]
        [ProducesResponseType(typeof(ICollection<FriendDTO>), 401)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await friendService.GetAll());
        }


        [HttpPost("[action]")]
        [ProducesResponseType(typeof(FriendDTO), 200)]
        //[ProducesResponseType(400)]
        public async Task<IActionResult> Add(FriendDTO friend)
        {
            try
            {
                await friendService.Add(friend);
                return Ok(friend);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 400)]
        [ProducesResponseType(typeof(int), 401)]
        public async Task<IActionResult> Get1()
        {
            return Ok((await friendService.GetAll()).Count);
        }

    }
}
