using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using taxi.Data;
using taxi.Models;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace taxi.Controllers
{
    public class CompanyTaxisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;


        public CompanyTaxisController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _env = env;
            _context = context;
        }

        // GET: CompanyTaxis
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyTaxis.ToListAsync());
        }

        // GET: CompanyTaxis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyTaxi = await _context.CompanyTaxis.SingleOrDefaultAsync(m => m.Id == id);
            if (companyTaxi == null)
            {
                return NotFound();
            }

            return View(companyTaxi);
        }

        // GET: CompanyTaxis/Create
        [Authorize(Roles = "Admins")]
        public IActionResult Create()
        {
            var model = new CompanyTaxiViewModel();

            return View(model);
        }

        // POST: CompanyTaxis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Create(CompanyTaxiViewModel model)
        {
            if (ModelState.IsValid)
            {
                var taxicompany = new CompanyTaxi
                {
                    AddressOffice = model.AddressOffice,
                    PhoneCompany = model.PhoneCompany,
                    Name = model.Name
                   
                };
                if (model.Logo != null)
                {
                    var filename = Path.GetFileName(ContentDispositionHeaderValue
             .Parse(model.Logo.ContentDisposition)
             .FileName.Trim('"'));
                    var extension = Path.GetExtension(filename);

                    if (extension != ".jpg" && extension != ".png")
                    {
                        throw new ArgumentException();
                    }

                    var serverPath = Path.Combine(_env.WebRootPath, "images");
                    serverPath = Path.Combine(serverPath, filename);

                    using (FileStream SourceStream = System.IO.File.Open(serverPath, FileMode.OpenOrCreate))
                    {
                        await model.Logo.CopyToAsync(SourceStream);
                    }

                    taxicompany.LogoUrl = "/images/" + filename;
                }
                _context.Add(taxicompany);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        // GET: CompanyTaxis/Edit/5
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyTaxi = await _context.CompanyTaxis.SingleOrDefaultAsync(m => m.Id == id);
            if (companyTaxi == null)
            {
                return NotFound();
            }

            var model = new CompanyTaxiViewModel
            {
                Item = companyTaxi,
                AddressOffice = companyTaxi.AddressOffice,
                PhoneCompany = companyTaxi.PhoneCompany,
                Name = companyTaxi.Name,
            };

            return View(model);
        }

        // POST: CompanyTaxis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Edit(int? id, CompanyTaxiViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyTaxi = await _context.CompanyTaxis.SingleOrDefaultAsync (m => m.Id == id);

            if (companyTaxi == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                companyTaxi.Name = model.Name;
                companyTaxi.PhoneCompany = model.PhoneCompany;
                companyTaxi.AddressOffice = model.AddressOffice;
                if (model.Logo != null)
                {
                    var filename = Path.GetFileName(ContentDispositionHeaderValue
             .Parse(model.Logo.ContentDisposition)
             .FileName.Trim('"'));
                    var extension = Path.GetExtension(filename);

                    if (extension != ".jpg" && extension != ".png")
                    {
                        throw new ArgumentException();
                    }

                    var serverPath = Path.Combine(_env.WebRootPath, "images");
                    serverPath = Path.Combine(serverPath, filename);

                    using (FileStream SourceStream = System.IO.File.Open(serverPath, FileMode.OpenOrCreate))
                    {
                        await model.Logo.CopyToAsync(SourceStream);
                    }

                    companyTaxi.LogoUrl = "/images/" + filename;
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");


            }
            model.Item = companyTaxi;
            return View(model);
        }
        [Authorize(Roles = "Admins")]
        // GET: CompanyTaxis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyTaxi = await _context.CompanyTaxis.SingleOrDefaultAsync(m => m.Id == id);
            if (companyTaxi == null)
            {
                return NotFound();
            }

            return View(companyTaxi);
        }

        // POST: CompanyTaxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyTaxi = await _context.CompanyTaxis.SingleOrDefaultAsync(m => m.Id == id);
            _context.CompanyTaxis.Remove(companyTaxi);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CompanyTaxiExists(int id)
        {
            return _context.CompanyTaxis.Any(e => e.Id == id);
        }
    }
}
