using BirthdayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResponseForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResponseForm(UserResponse userResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(userResponse);
                return View("Thanks", userResponse);

            }
            else return View();
        }

        public ViewResult ListResponse()
        {
            return View(Repository.Responses);
        }
        public ViewResult Details(int id)
        {
            return View(Repository.Responses.Find(x=>x.Id==id));
        }

        public ViewResult Update(int id)
        {
            return View(Repository.Responses.Find(x => x.Id == id));
        }

        [HttpPost]
        public ViewResult Update(UserResponse userResponse)
        {
            if(ModelState.IsValid)
            {
                Repository.Update(userResponse);
                ViewBag.Success = "Your Data Has Been Saved";
                return View();
            }
            else
            {
                return View();
            }
        }
        public ViewResult Delete(int id)
        {
            return View(Repository.Responses.Find(x => x.Id == id));
        }
        [ValidateAntiForgeryToken]
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("ListResponse");
        }
    }
}