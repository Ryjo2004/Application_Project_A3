using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bpassignment.Data;
using Bpassignment.Models;

namespace Bpassignment.Controllers
{
    public class BPMeasurementsController : Controller
    {
        private readonly BpMeasurementContext _context;

        public BPMeasurementsController(BpMeasurementContext context)
        {
            _context = context;
        }

        // GET: BPMeasurements
        public async Task<IActionResult> Index()
        {
            var bpMeasurementContext = _context.BPMeasurement.Include(b => b.Position);
            return View(await bpMeasurementContext.ToListAsync());
        }

        // GET: BPMeasurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurement
                .Include(b => b.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bPMeasurement == null)
            {
                return NotFound();
            }

            return View(bPMeasurement);
        }

        // GET: BPMeasurements/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Id");
            return View();
        }

        // POST: BPMeasurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Systolic,Diastolic,MeasurementDate,PositionId")] BPMeasurement bPMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bPMeasurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Id", bPMeasurement.PositionId);
            return View(bPMeasurement);
        }

        // GET: BPMeasurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurement.FindAsync(id);
            if (bPMeasurement == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Id", bPMeasurement.PositionId);
            return View(bPMeasurement);
        }

        // POST: BPMeasurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Systolic,Diastolic,MeasurementDate,PositionId")] BPMeasurement bPMeasurement)
        {
            if (id != bPMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bPMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BPMeasurementExists(bPMeasurement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Id", bPMeasurement.PositionId);
            return View(bPMeasurement);
        }

        // GET: BPMeasurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurement
                .Include(b => b.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bPMeasurement == null)
            {
                return NotFound();
            }

            return View(bPMeasurement);
        }

        // POST: BPMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bPMeasurement = await _context.BPMeasurement.FindAsync(id);
            if (bPMeasurement != null)
            {
                _context.BPMeasurement.Remove(bPMeasurement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BPMeasurementExists(int id)
        {
            return _context.BPMeasurement.Any(e => e.Id == id);
        }
    }
}
