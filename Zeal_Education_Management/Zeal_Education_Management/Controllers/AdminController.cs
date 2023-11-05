using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zeal_Education_Management.Models;

namespace Zeal_Education_Management.Controllers
{
	public class AdminController : Controller
	{
        private readonly ZealDBContext _dbContext;
        public AdminController(ZealDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IActionResult Index()
		{
			return View();
		}

        public IActionResult AdminSignup()
        {
            return View();
        }
		public IActionResult Home()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AdminSignUp(AdminModel model)
		{
			if (ModelState.IsValid)
			{
				var existingAdmin = await _dbContext.tbl_Admin_us.FirstOrDefaultAsync();
				if (existingAdmin != null)
				{
					TempData["AlertMessage"] = "An admin already exists.";
					return View(model);
				}

				_dbContext.Add(model);
				await _dbContext.SaveChangesAsync();

				HttpContext.Session.SetString("AdminSessionID", "1");

				TempData["SuccessMessage"] = "Sign up successful!";

				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

	

		[HttpPost]
		public async Task<IActionResult> AdminLogin(string userName, string password)
		{
			var user = await _dbContext.tbl_Admin_us.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);

			if (user == null)
			{
				TempData["AlertMessage"] = "Invalid username or password.";
				return View();
			}


			return RedirectToAction("Home", "Admin");
		}

		public IActionResult ForgotPassword()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> ForgotPassword(string UserName)
		{
			var user = await _dbContext.tbl_Admin_us.FirstOrDefaultAsync(u => u.UserName == UserName);

			if (user == null)
			{
				TempData["AlertMessage"] = "UserName not found.";
				return View("ResetPassword");
			}



			return RedirectToAction(nameof(Index));
		}


		[HttpPost]
		public async Task<IActionResult> ResetPassword(string userName, string password)
		{
			var user = await _dbContext.tbl_Admin_us.FirstOrDefaultAsync(u => u.UserName == userName);

			if (user == null)
			{
				return View();
			}

			user.Password = password; 
			_dbContext.Update(user);
			await _dbContext.SaveChangesAsync();

			TempData["SuccessMessage"] = "Password reset successful!";

			return RedirectToAction("Index","Admin");
		}

        public IActionResult AddJobs()
        {
            return View();
        }



		[HttpPost]
		public IActionResult AddJobs(JobModel job)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Add(job);
				_dbContext.SaveChanges();

				TempData["AlertMessages"] = "Job added successfully!";


				return RedirectToAction("Jobs");
			}
			return View(job);
		}


		public IActionResult Jobs()
		{
			var jobs = _dbContext.Jobs.ToList();
			return View(jobs);
		}

		public IActionResult Delete(int id)
		{
			var job = _dbContext.Jobs.FirstOrDefault(j => j.Id == id);
			if (job != null)
			{
				_dbContext.Jobs.Remove(job);
				_dbContext.SaveChanges();
			}
			return RedirectToAction("Jobs");
		}


		public IActionResult JobApplication()
		{
			var jobsApply = _dbContext.JobApplication.ToList();
			return View(jobsApply);
		}

	}
}
