using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wedding_Planner.Models;
/////
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
////

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {

        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        //////////////////////////////////////////////////
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            Login_Register_wrapper wrapper=new Login_Register_wrapper();
            return View(wrapper);
        }

        [HttpPost("process_register")]
        public IActionResult Process_Register(User reg)
        {
            // Check initial ModelState
            if(ModelState.IsValid)
            {
                // If a User exists with provided email
                if(dbContext.Useres.Any(u => u.Email == reg.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("Email", "Email already in use!");
                    
                    // You may consider returning to the View at this point
                    Login_Register_wrapper wrapper=new Login_Register_wrapper();
                    return View("Index",wrapper);
                }
                else{
                    HttpContext.Session.SetString("Firstname", reg.Firstname);
                    HttpContext.Session.SetInt32("id",reg.UserId);
                    //////
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    reg.Password = Hasher.HashPassword(reg, reg.Password);
                    //////
                    dbContext.Add(reg);
                    dbContext.SaveChanges(); 
                    return RedirectToAction("Dashboard");
                }
            }else{
                Login_Register_wrapper wrapper=new Login_Register_wrapper();
                return View("Index",wrapper);
            }
            // other code
        } 

        [HttpPost("process_login")]
        public IActionResult Process_Login(Login log)
        {
            if(ModelState.IsValid)
            {
               
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Useres.FirstOrDefault(u => u.Email == log.logEmail);
                // If no user exists with provided email          
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("logEmail", "Invalid Email/Password");
                    Login_Register_wrapper wrapper=new Login_Register_wrapper();
                    return View("Index",wrapper);
                }else{
                    // Initialize hasher object
                    var hasher = new PasswordHasher<Login>();
                    
                    // varify provided password against hash stored in db
                    var result = hasher.VerifyHashedPassword(log, userInDb.Password, log.logPassword);
                    
                    // result can be compared to 0 for failure    
                    if(result == 0)
                    { 
                      
                        // handle failure (this should be similar to how "existing email" is handled)
                        ModelState.AddModelError("logPassword", "Invalid Email/Password");
                        Login_Register_wrapper wrapper=new Login_Register_wrapper();
                        return View("Index",wrapper);              
                    }
                    else{                
                       
                        HttpContext.Session.SetString("Firstname", userInDb.Firstname);
                        HttpContext.Session.SetInt32("id",userInDb.UserId);
                        return RedirectToAction("Dashboard"); 
                    }
                }
            }else{
                Login_Register_wrapper wrapper=new Login_Register_wrapper();
                return View("Index",wrapper);
            }

        }
        
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Firstname");
            HttpContext.Session.Remove("id");

            return RedirectToAction("Index");
        }


//////////////////////////////////////////////////////////////////////////////
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("Firstname")!=null){
                List<WeddingPlan> OldAllplans=dbContext.WeddingPlanes
                .Include(w=>w.Guests)
                .ToList();
                foreach(WeddingPlan x in OldAllplans)
                {
                    if(DateTime.ParseExact(x.Date, "MM/dd/yyyy",System.Globalization.CultureInfo.InvariantCulture)<DateTime.Now)
                    {
                        WeddingPlan oneplan=dbContext.WeddingPlanes.FirstOrDefault(w=>w.WeddingPlanId==x.WeddingPlanId);
                        dbContext.WeddingPlanes.Remove(oneplan);
                        dbContext.SaveChanges();
                    }
                }
                List<WeddingPlan> Allplans=dbContext.WeddingPlanes
                .Include(w=>w.Guests)
                .ToList();
                ViewBag.userid=(int)HttpContext.Session.GetInt32("id");
                return View(Allplans);
            }else{
                return RedirectToAction("Index");
            }
        }


        [HttpGet("un-rsvp/{PlanId}")]
        public IActionResult Unrsvp(int PlanId)
        {
            if(HttpContext.Session.GetString("Firstname")!=null){
                List<Resevation> reservations=dbContext.Resevationes.Where(r=>r.WeddingPlanId==PlanId).ToList();
                int reservetionId=0;
                foreach(Resevation x in reservations){
                    if(x.UserId==(int)HttpContext.Session.GetInt32("id"))
                    {
                        reservetionId=x.ResevationId;
                    }
                }
                Resevation reserv=dbContext.Resevationes.FirstOrDefault(r=>r.ResevationId==reservetionId);
                dbContext.Resevationes.Remove(reserv);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }else{
                return RedirectToAction("Index");
            }
        }

        [HttpGet("rsvp/{PlanId}")]
        public IActionResult Rsvp(int PlanId)
        {
            if(HttpContext.Session.GetString("Firstname")!=null){
                Resevation reservation=new Resevation();
                reservation.UserId=(int)HttpContext.Session.GetInt32("id");
                reservation.WeddingPlanId=PlanId;
                dbContext.Resevationes.Add(reservation);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }else{
                return RedirectToAction("Index");
            }
        }

        
        [HttpGet("delete/{PlanId}")]
        public IActionResult Delete(int PlanId)
        {
            if(HttpContext.Session.GetString("Firstname")!=null){
                WeddingPlan plan=dbContext.WeddingPlanes.FirstOrDefault(p=>p.WeddingPlanId==PlanId);
                dbContext.WeddingPlanes.Remove(plan);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }else{
                return RedirectToAction("Index");
            }

        }

/////////////////////////////////////
        [HttpPost("process_newplan")]
        public IActionResult Process_newplan(WeddingPlan WeddingPlan)
        {
            if(HttpContext.Session.GetString("Firstname")!=null){
                if(ModelState.IsValid)
                {   
                    if(DateTime.ParseExact(WeddingPlan.Date, "MM/dd/yyyy",System.Globalization.CultureInfo.InvariantCulture)<DateTime.Now){
                        ModelState.AddModelError("Date", "Date can not be ealy than today!");
                        return View("AddWeddingPlan");
                    }
                    
                    List<string> address = WeddingPlan.Address.Split(',').ToList<string>();

                    if(address.Count!=5){
                        ModelState.AddModelError("Address", "Invalid Address");
                        return View("AddWeddingPlan");
                    }
                    else if(!(int.TryParse(address[3], out int w))){
                        ModelState.AddModelError("Address", "Invalid Address");
                        return View("AddWeddingPlan");
                    }

                    WeddingPlan.UserId=(int)HttpContext.Session.GetInt32("id");
                    dbContext.Add(WeddingPlan);
                    dbContext.SaveChanges();
                    return RedirectToAction("Dashboard");
                    
                }else{
                    return View("AddWeddingPlan");
                }
            }else{
                return RedirectToAction("Index");
            }
        }

        [HttpGet("new")]
        public IActionResult AddWeddingPlan()
        {
            if(HttpContext.Session.GetString("Firstname")!=null){
                return View();
            }else{
                return RedirectToAction("Index");
            }
        }
        ////////////////////
        [HttpGet("detail/{planid}")]
        public IActionResult Display_Plan_Detail(int planid)
        {
            List<Resevation> guest=dbContext.Resevationes
            .Include(r=>r.User)
            .Where(r=>r.WeddingPlanId==planid)
            .ToList();            

            WeddingPlan oneplan=dbContext.WeddingPlanes
            .FirstOrDefault(w=>w.WeddingPlanId==planid);

            Display_one_plan Display_one_plan=new Display_one_plan
            {
                Guest=guest,
                Oneplan=oneplan
            };

            return View(Display_one_plan);
        }
        
    }
}
