using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using taxi.Data;
using taxi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace taxi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public HomeController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _env = env;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }


        [Authorize(Roles = "Admins")]
        public IActionResult Create()
        {
            var model = new NewsViewModel();

            return View(model);
        }

        // POST: CompanyTaxis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Create(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = new News
                {
                    DescriptionNews = model.DescriptionNews,
                    Name = model.Name
                };
                if (model.Picture != null)
                {
                    var filename = Path.GetFileName(ContentDispositionHeaderValue
             .Parse(model.Picture.ContentDisposition)
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
                        await model.Picture.CopyToAsync(SourceStream);
                    }

                    news.PictureUrl = "/images/" + filename;
                }
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult Error()
        {
            return View();
        }
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: CompanyTaxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.SingleOrDefaultAsync(m => m.Id == id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool CompanyTaxiExists(int id)
        {
            return _context.CompanyTaxis.Any(e => e.Id == id);
        }
    }
}
