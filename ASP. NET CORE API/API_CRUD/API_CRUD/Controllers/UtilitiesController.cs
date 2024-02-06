using Api_Estandar.Models.Response;
using InsAPIGenerics.Logic.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DAVIVIENDA_SINPEMOVIL.Controllers
{
    [Route("Api_Core")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        /// <summary>Ecriptar String.</summary>
        [HttpPost]
        [Route("Utilities/Encrypt")]
        public async Task<MResponseData> Encrypt(string texto)
        {
            MResponseData response = new MResponseData();
            string encrypted = General_Functions.Encrypt(texto);

            response.success = true;
            response.data = encrypted;

            return response;
        }
        /// <summary>Desencriptar Datos encriptado.</summary>
        [HttpPost]
        [Route("Utilities/Decrypt")]
        public async Task<MResponseData> Decrypt(string texto)
        {
            MResponseData response = new MResponseData();
            string decrypted = General_Functions.Desencrypt(texto);

            response.success = true;
            response.data = decrypted;

            return response;
        }

    }
}
