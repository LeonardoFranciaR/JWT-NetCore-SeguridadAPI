using JWT_NetCore.Core.Abstraccions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NetCore.Services.Controllers
{
    //Mapeo para el path del controlador
    [Route("api/[controller]")]
    [ApiController]

    //Clase de tipo ControladorBase
    public class TokenController : ControllerBase
    {
        //SymmetricSecurityKey: clase base abstracta para todas las claves que se generan utilizando algoritmos simétricos
        public static readonly SymmetricSecurityKey SIGNING_KEY_NSC = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));

        //EndPoint GetToken de método Post
        [HttpPost, Route("GetToken")]
        //Podría generar un GUID para cada usuario así identificar la petición
        public IActionResult GetTokenResult (string GUID)
        {
            if (GUID == Constants.guidValidate)
                return new ObjectResult(GetTokenResultPrivate(GUID));
            else
                return BadRequest();
        }

        //Método llamado después de la autenticación del GUID
        private object GetTokenResultPrivate(string GUID)
        {
            //En la variable "token" obtendremos el algoritmo de respuesta por la petición
            var tokenResult = new JwtSecurityToken(
                //Ingresar los valores de composición del Token en la Wiki del Repo indica las 3 partes
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, GUID)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(5)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY_NSC, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenResult);
        }

    }
}
