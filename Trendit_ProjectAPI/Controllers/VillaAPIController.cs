using Microsoft.AspNetCore.Mvc;
using Trendit_ProjectAPI.Data;
using Trendit_ProjectAPI.Models;
using Trendit_ProjectAPI.Models.Dto;

namespace Trendit_ProjectAPI.Controllers
{
    [Route("api/VillaAPI")]
   //or [Route("api/[controller]")] it will give the name of the controller VillaAPI but not preferred
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        // if not specified it will be HttpGet by default 
        public IEnumerable<VillaDTO> getVillas ()
        {
            return VillaStore.villaList;
        }
        [HttpGet("id")]
        public VillaDTO getVilla(int id)
        {
            return VillaStore.villaList.FirstOrDefault(villa=>villa.Id==id);
            //FirstOrDefault is a linq methode to get the first element that match or the default null
        }
    }
}
