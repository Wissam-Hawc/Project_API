using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trendit_ProjectAPI.Data;
using Trendit_ProjectAPI.Models;
using Trendit_ProjectAPI.Models.Dto;
using Trendit_ProjectAPI.Repository.IRepository;

namespace Trendit_ProjectAPI.Controllers
{
    [Route("api/VillaAPI")]
    //or [Route("api/[controller]")] it will give the name of the controller VillaAPI but not preferred
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaAPIController(IVillaRepository dbVilla, IMapper mapper)
        {
            _dbVilla = dbVilla;
            _mapper = mapper;
        }


        [HttpGet]
        // if not specified it will be HttpGet by default 
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<VillaDTO>>> getVillas()
        {
            IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
            return Ok(_mapper.Map<List<VillaDTO>>(villaList));
        }
        [HttpGet("id", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(200, Type = typeof(VillaDTO))]
        public async Task<ActionResult<VillaDTO>> getVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbVilla.GetAsync(villa => villa.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VillaDTO>(villa));
            //FirstOrDefault is a linq methode to get the first element that match or the default null
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO createDTO)
        {
            if (await _dbVilla.GetAsync(villa => villa.Name.ToLower() == createDTO.Name.ToLower()) != null)
            /*here will get the first villa in villastore who s name equal to the one send, if no result it will
            return null so no duplication names 
            */
            {
                ModelState.AddModelError("CustomError", "Villa Already Exist");
                return BadRequest(ModelState);
            }
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Villa model= _mapper.Map<Villa>(createDTO);
            await _dbVilla.CreateAsync(model);

            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
            //the id because the getVilla route needs an id also 

        }

        [HttpDelete("id", Name = "DeleteVilla")]
        //the possible response codes
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteVilla(int id)
        //IactionResult because we will not return a type 
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa =await _dbVilla.GetAsync(villa => villa.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            await _dbVilla.RemoveAsync(villa);
            return NoContent();
        }

        [HttpPut("id", Name = "UpdateVilla")]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }
            Villa model = _mapper.Map<Villa>(updateDTO);
            await _dbVilla.UpdateAsync(model);

            return NoContent();
        }

        [HttpPatch("id", Name = "UpdatePartialVilla")]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            //tracked false because we need no tracking so there will be no error by tracking 2 same time
            var villa = await _dbVilla.GetAsync(villa => villa.Id == id,tracked:false);
            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
            if (villa == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(villaDTO, ModelState);
            Villa model = _mapper.Map<Villa>(villaDTO);
            await _dbVilla.UpdateAsync(model);
            //if any error about the condition of the attributes it will be stored in modelstate
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
