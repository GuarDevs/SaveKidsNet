using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Criminals;
using SaveKids.Service.DTOs.Criminals;
using SaveKids.Service.Interfaces;

namespace SaveKidsNet.Wep.Controllers
{
    public class CriminalsController : Controller
    {
        private readonly ICriminalService _criminalService;

        public CriminalsController(ICriminalService criminalService)
        {
            _criminalService = criminalService;
        }

        public async Task<IActionResult> Index(PaginationParams paginationParams)
            => View(await _criminalService.RetrieveAllAsync(paginationParams));

        public async Task<IActionResult> Details(long id)
            => View(await _criminalService.RetrieveByIdAsync(id));

        public IActionResult Create()
            => View();

        // POST: Criminals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriminalCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await _criminalService.AddAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Criminals/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var criminal = await _criminalService.RetrieveByIdAsync(id);
            if (criminal is null)
            {
                return NotFound();
            }
            return View(criminal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CriminalUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _criminalService.ModifyAsync(dto);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var criminal = await _criminalService.RetrieveByIdAsync(id);
            if (criminal is null)
            {
                return NotFound();
            }

            return View(criminal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var criminal = await _criminalService.RetrieveByIdAsync(id);
            if (criminal != null)
            {
                await _criminalService.RemoveAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
