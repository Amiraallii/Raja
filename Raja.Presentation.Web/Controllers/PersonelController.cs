using Microsoft.AspNetCore.Mvc;
using Raja.Application.Contract.Dto;
using Raja.Application.Contract.IServices;
using Raja.Application.Services;

namespace Raja.Presentation.Web.Controllers
{
    public class PersonelController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PersonnelController : ControllerBase
        {
            private readonly IPersonelService _personnelService;

            public PersonnelController(IPersonelService personnelService)
            {
                _personnelService = personnelService;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetAll()
            {
                var result = await _personnelService.GetAll(new CancellationToken());
                if (result == null)
                    return NotFound();

                return Ok(result);
            }


        }
    }
}
