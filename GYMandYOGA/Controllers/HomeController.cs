using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYMandYOGA.Models;

namespace GYMandYOGA.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        MPROGYMANDYOGAEntities db = new MPROGYMANDYOGAEntities();

        public ActionResult Index()
        {
            return View();
        }
       
      
        public ActionResult contact()    // Get Action run of view page
        {
            return View();
        }

       [HttpPost]
        public ActionResult contact(TBL_Contact con)
        {
            try
            {
                con.contactdate = DateTime.Now.ToString();
                db.TBL_Contact.Add(con);
                db.SaveChanges();
                Response.Write("<script>alert('Record Save Successfully') </script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record not Save') </script>");
            }

            return View();
        }

        public ActionResult picture()
        {
            return View();
        }


        public ActionResult video()
        {
            return View();
        }

        public ActionResult member()
        {
            return View();
        }
        [HttpPost]
        public ActionResult member(TBL_Members reg,string hdn1,string ct1)
        {
            try
            {
                if (hdn1 == ct1)
                {
                    reg.Regdate = DateTime.Now.ToString();
                    db.TBL_Members.Add(reg);
                    db.SaveChanges();
                    Response.Write("<script>alert('Record Save Successfully') </script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Captcha Code')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record not Save') </script>");
            }

            return View();
        }

        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(TBL_Login lg)
        {
            try
            {
                TBL_Login t1 = db.TBL_Login.Where(x => x.UserId == lg.UserId && x.Password == lg.Password).SingleOrDefault();
                if (t1 != null)
                {
                    Session["aid"]=lg.UserId;  // set of session
                    Response.Write("<script>alert('Welcome to Admin Zone');window.location.href='/AdminZone/Index'</script>");
                }
                else
                {
                    Response.Write("<script>('Invailid')</script>");
                }

            }
            catch (Exception ex)
            { 
            
            }
            return View();
        }

        public ActionResult review()
        {
            return View();
        }

       
        }

    }

