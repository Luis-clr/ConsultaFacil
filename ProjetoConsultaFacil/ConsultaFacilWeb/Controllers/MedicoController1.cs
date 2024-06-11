using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaFacilWeb.Controllers
{
    public class MedicoController1 : Controller
    {
        // GET: MedicoController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicoController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
