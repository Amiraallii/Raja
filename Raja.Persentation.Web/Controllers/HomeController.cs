using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raja.Application.Contract.Dto;
using Raja.Application.Contract.IServices;
using Raja.Persentation.Web.Models;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Raja.Persentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonelService personelService;

        public HomeController(IPersonelService personelService)
        {
            this.personelService = personelService;
        }

        public async Task<IActionResult> Index(PersonelDto personel,CancellationToken ct)
        {
            ViewData["PersonelList"] = await personelService.GetAll(ct);

            return View(personel);
        }

        public async Task<IActionResult> Report(CancellationToken ct)
        {
            ViewData["PersonelList"] = await personelService.GetAll(ct);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonelDto personel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index), personel);

            await personelService.Add(personel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonelDto personel,CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index), personel);

            await personelService.Edit(personel, ct);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id, CancellationToken ct)
        {
            ViewData["PersonelList"] = await personelService.GetAll(ct);
            var personel = await personelService.Get(id, ct);
            return View(personel);

        }
        public async Task<IActionResult> Remove(int id)
        {
            await personelService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> RemoveMobileNumber(int id)
        {
            await personelService.RemoveMobileNumber(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
