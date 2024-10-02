using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYMandYOGA.Models;

namespace GYMandYOGA.Controllers
{
    public class AdminZoneController : Controller
    {
        //
        // GET: /AdminZone/
        MPROGYMANDYOGAEntities db = new MPROGYMANDYOGAEntities();

        public ActionResult Index()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('LogIn First then go to Next Zone');window.location.href='/Home/login'</script>");
            }
            return View();
        }
        public ActionResult ContactMGMT()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('LogIn First then go to Next Zone');window.location.href='/Home/login'</script>");
            }
            List<TBL_Contact> lst = null;
            lst = db.TBL_Contact.ToList();
            return View(lst);
        }
        public ActionResult MemberMGMT()
        {
            if (Session["aid"] != null)
            {

            }
            else
            {
                Response.Write("<script>alert('LogIn First then go to Next Zone');window.location.href='/Home/login'</script>");
            }
            List<TBL_Members> lst = null;
            lst = db.TBL_Members.ToList();

            return View(lst);
        }


        public ActionResult ChangePassword()
        {
            return View();
        }
       [HttpPost]
        public ActionResult ChangePassword(string oldpass, string newpass, string confirmpass)
     {
         if (newpass == confirmpass)
         {
             string UserId = Session["aid"].ToString();
             TBL_Login lg = db.TBL_Login.Where(x => x.Password == oldpass && x.UserId == x.UserId).SingleOrDefault();
             lg.Password = newpass;
             db.SaveChanges();
             Response.Write("<script>alert('Your Password Changed');window.location.href='/Home/login'</script>");
         }
         else
         {
             Response.Write("<script>alert('Please Enter ')</script>");
         }
           return View();
       }

        public void logout()
        {
            Session.Abandon();
            Response.Write("<script>alert('LogOut');window.location.href='/Home/login'</script>");
        }

        public void Delete()
        {
            try
            {
                string m = Request.QueryString["m"];
                TBL_Members TBL = db.TBL_Members.SingleOrDefault(X => X.mob == m);
                db.TBL_Members.Remove(TBL);
                db.SaveChanges();
                Response.Write("<script>alert('Record Delete Successfull');window.location.href='/AdminZone/MemberMGMT'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record Not Delete ')</script>");
            }
        }
        [HttpGet]
        public ActionResult UpdateRecord()
        {
            string aid = Request.QueryString["U"];
            TBL_Members reg = db.TBL_Members.SingleOrDefault(a => a.Name == aid);
            return View(reg);
        }
        [HttpPost]
        public void UpdateRecord(TBL_Members reg,string mob)
        {
            TBL_Members rg = db.TBL_Members.SingleOrDefault(a => a.mob == mob);
            try
            {
                rg.Name = reg.Name;
                rg.mob = reg.mob;
                rg.address = reg.address;
                rg.city = reg.city;
                rg.pplan = reg.pplan;
                rg.gender = reg.gender;
                rg.Regdate = DateTime.Now.ToString();
                db.SaveChanges();
                Response.Write("<script>alert('Record Update Successfully');window.location.href='/AdminZone/MemberMGMT'</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Record Not Update')</script>");
            }

        }
        
    }
}
