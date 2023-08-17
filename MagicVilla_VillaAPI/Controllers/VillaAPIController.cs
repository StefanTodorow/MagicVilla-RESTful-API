using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    [Route("api/VillaAPI")]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;
        private readonly ApplicationDBContext _db;

        public VillaAPIController(ApplicationDBContext db, ILogger<VillaAPIController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Getting all villas.");

            return Ok(_db.Villas);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            _logger.LogInformation($"Getting villa with Id: + {id}.");

            if (id == 0)
            {
                _logger.LogError("GetVilla Error with Id: + " + id);

                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
                return NotFound();

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDTO)
        {
            _logger.LogInformation("Creating new villa.");

            if (villaDTO == null)
                return BadRequest(villaDTO);

            if(_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "Villa already exists");
                return BadRequest(villaDTO);
            }

            if (villaDTO.Id != 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var model = new Villa(villaDTO);

            _db.Villas.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO );
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            _logger.LogInformation($"Deleting villa with Id: + {id}.");

            if (id == 0)
                return BadRequest();

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

            if (villa == null)
                return NotFound();

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villaDTO)
        {
            _logger.LogInformation($"Updating villa with Id: + {id}.");

            if (villaDTO == null || id != villaDTO.Id)
                return BadRequest();

            var model = new Villa(villaDTO);

            _db.Villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            _logger.LogInformation($"Partially updating villa with Id: + {id}.");

            if (patchDTO == null || id == 0)
                return BadRequest();

            var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);

            if (villa == null)
                return BadRequest();

            var villaDTO = new VillaDTO(villa);

            patchDTO.ApplyTo(villaDTO, ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var model = new Villa(villaDTO);

            _db.Villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
