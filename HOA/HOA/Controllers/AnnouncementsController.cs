using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HOA.Models;
using HOA.Services.Interfaces;

namespace HOA.Controllers
{
    public class AnnouncementsController : Controller
    {
        private IAnnouncementsService _announcementsService;


        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        // GET: Announcements
        public IActionResult Index(string searchQuery)
        {
            ViewData["SearchQuery"] = searchQuery;
            var announcements = string.IsNullOrEmpty(searchQuery)
                ? _announcementsService.GetAllAnnouncements()
                : _announcementsService.SearchAnnouncementsByTitle(searchQuery);
            return View(announcements);
        }

        // GET: Announcements/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = _announcementsService.GetAnnouncementsById((int)id);

            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // GET: Announcements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,Date")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _announcementsService.AddAnnouncement(announcement);
                return RedirectToAction(nameof(Index));
            }
            return View(announcement);
        }

        // GET: Announcements/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = _announcementsService.GetAnnouncementsById((int)id);
            
            if (announcement == null)
            {
                return NotFound();
            }
            return View(announcement);
        }

        // POST: Announcements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,TaskName,AssignedPersonnel,Date")] Announcement announcement)
        {
            if (id != announcement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _announcementsService.UpdateAnnouncement(announcement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementExists(announcement.Id))
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
            return View(announcement);
        }

        // GET: Announcements/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var announcement = _announcementsService.GetAnnouncementsById((int)id);

            if (announcement == null)
            {
                return NotFound();
            }

            return View(announcement);
        }

        // POST: Announcements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var announcement = _announcementsService.GetAnnouncementsById(id);
            if (announcement != null)
            {
                _announcementsService.DeleteAnnouncement(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementExists(int id)
        {
            return _announcementsService.GetAnnouncementsById(id) != null;
        }
    }
}
