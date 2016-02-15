using Domain;
using Log;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Service;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
       private IUtilisateurService db = new UtilisateurService();

       
        public ActionResult Index()
        {
           
                return View();
          



        }

        [HttpPost]
        public async Task<ActionResult> Index(Utilisateur g)
        {

            Utilisateur result;
            try
            {

                if (ModelState.IsValid)
                {

                    if ((result = db.Authentification(g)) != null)
                    {
                        if (result.etatUtilisateur == true)
                        {

                            Session["identifiant"] = result;
                            Session["Nom"] = result.Personnel.nom +" "+ result.Personnel.prenom;
                            Session["Role"] = result.Personnel.Role.libelle;

                            return RedirectToAction("RapportBien", "Admin");
                        }
                        else
                        {
                            //
                            ViewBag.msg1 = "Votre Compte est désactivé !!! ";
                            return View();

                          
                        }
                    }
                    else
                        ViewBag.msg1 = "Vérifiez Votre Login ou Password !!!";
                    return View();
                    // ModelState.AddModelError("Error", "Vérifiez Votre Login ou Password !!!");
                }
                else
                {
                    ViewBag.msg1 = "Wrong Input";
                    return View();
                }
            }

            catch (Exception ex)
            {
                LogThread.WriteLine(ex.Message);
                return View();
            }

        }

       
        public ActionResult Logout()
        {

           
            db.SaveEmploye();
            Session["identifiant"] = null;
            Session["id"] = null;
            Session["role"] = null;
            return RedirectToAction("Index", "Home");


        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}