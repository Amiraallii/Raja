using Microsoft.AspNetCore.Identity;
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

            [HttpPost]
            public async Task<IActionResult> Add(PersonelDto personel)
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(Index), personel);

                await _personnelService.Add(personel);
                return RedirectToAction(nameof(Index));
            }

            [HttpPost]
            public async Task<IActionResult> Edit(PersonelDto personel, CancellationToken ct)
            {
                if (!ModelState.IsValid)
                    return RedirectToAction(nameof(Index), personel);

                await _personnelService.Edit(personel, ct);
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Remove(int id)
            {
                await _personnelService.Remove(id);
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Detail(int id, CancellationToken ct)
            {
                var personel = await _personnelService.Get(id, ct);
                return RedirectToAction(nameof(Index), personel);
            }
        }
    }
}
