using Futbolchi_10052023_.DTOs;
using Futbolchi_10052023_.Servives;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Futbolchi_10052023_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolchiController : ControllerBase
    {
       IFutbolchiService service;

        public FutbolchiController(IFutbolchiService service)
        {
            this.service = service;
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await service.GetAllAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddFutbolchiDTO futbolchiDTO)
        {
           await service.AddAsync(futbolchiDTO);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, AddFutbolchiDTO futbolchiDTO)
        {
            await service.UpdateAsync(id, futbolchiDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
