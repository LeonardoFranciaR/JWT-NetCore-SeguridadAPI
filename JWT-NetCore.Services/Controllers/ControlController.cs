using System.Threading.Tasks;
using JWT_NetCore.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_NetCore.Services.Controllers
{
    //Pide Autorización de Token
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ControlController : ControllerBase
    {
        //Invocar el interfaz
        private readonly IInformationCreator _informationCreator;

        public ControlController(IInformationCreator informationCreator)
        {
            _informationCreator = informationCreator;
        }

        // GET api/control
        //Para invocar tenemos que llamar al servidor "localhost:port""/api/control/Router"
        [HttpGet, Route("GetExample")]
        public async Task<IActionResult> UpdateValuePreferences()
        {            
            return Ok(_informationCreator.GetInformationCreator());
        }
    }
}
