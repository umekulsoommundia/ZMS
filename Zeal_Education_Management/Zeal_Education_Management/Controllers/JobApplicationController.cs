using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zeal_Education_Management.Models;
using System.Diagnostics;
using System;

namespace Zeal_Education_Management.Controllers
{
	public class JobApplicationController : Controller
	{
		private readonly ZealDBContext _dbContext;
		public JobApplicationController(ZealDBContext dBContext)
		{
			_dbContext = dBContext;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ApplyJob(ViewModel model)
		{
			
				if (model.JobApplication.ImageFile != null)
				{
					using var memoryStream = new MemoryStream();
					await model.JobApplication.ImageFile.CopyToAsync(memoryStream);
					model.JobApplication.Image = memoryStream.ToArray();
				}

				if (model.JobApplication.ResumeFile != null)
				{
					using var memoryStream = new MemoryStream();
					await model.JobApplication.ResumeFile.CopyToAsync(memoryStream);
					model.JobApplication.Resume = memoryStream.ToArray();
				}

				_dbContext.JobApplication.Add(model.JobApplication);
				await _dbContext.SaveChangesAsync();

			      return RedirectToAction("Index", "Website");
			
		
		}


	
	}
}
