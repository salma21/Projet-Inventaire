using Domain;
using Log;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class RoleController : Controller
    {
        private IRoleService db = new RoleService();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRole()
        {
            var Role = db.GetRoles();
            return View(Role);
        }
        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                var archive = BissInventaireEntities.Instance.Role.Find(id);

                return View(archive);
            }
            catch (Exception ex)
            {


                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Role/Create
        public ActionResult CreateRole()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult CreateRole(Role Catm, FormCollection collection)
        {
            try
            {
                BissInventaireEntities.Instance.Role.Add(Catm);
                BissInventaireEntities.Instance.SaveChanges();
                return RedirectToAction("GetRole");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            var role = db.GetRole(id);
          
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(Role role, FormCollection collection)
        {
            try
            {
                db.UpdateRoleDetached(role);
                db.SaveRole();

                return RedirectToAction("GetRole");
            }
            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
