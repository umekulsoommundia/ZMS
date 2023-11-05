using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zeal_Education_Management.Models;

namespace Zeal_Education_Management.Controllers
{
	public class WebsiteController : Controller
	{

		private readonly ZealDBContext _dbContext;
		public WebsiteController(ZealDBContext dBContext)
		{
			_dbContext = dBContext;
		}
		public IActionResult Index()
		{

			var viewModel = new ViewModel
			{
				Jobs = _dbContext.Jobs.ToList(),
				JobApplication = new JobApplicationModel(),
				Courses = _dbContext.Courses.ToList(),
				CourseApplication = new CourseApplicationModel()

			};
			return View(viewModel);
		
		}


		
	}
}
