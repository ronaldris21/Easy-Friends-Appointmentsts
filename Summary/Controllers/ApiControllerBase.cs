using Microsoft.AspNetCore.Mvc;
using Summary.Core.Abstraction;

namespace Summary.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        protected IDbContext DbContext => (IDbContext) HttpContext.RequestServices.GetService(typeof(IDbContext));
    }
}
