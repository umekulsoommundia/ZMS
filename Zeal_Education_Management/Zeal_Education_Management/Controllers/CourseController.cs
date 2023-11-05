using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zeal_Education_Management.Models;

namespace Zeal_Education_Management.Controllers
{
	public class CourseController : Controller
	{
		private readonly ZealDBContext _dbContext;
		public CourseController(ZealDBContext dBContext)
		{
			_dbContext = dBContext;
		}

		public IActionResult Index()
		{
			var courses = _dbContext.Courses.ToList();
			return View(courses);
		}

		public IActionResult CreateCourse()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateCourse(CourseModel course, IFormFile image)
		{
			if (!ModelState.IsValid)
			{
				return View(course);
			}

			var tags = course.Tags.Split(',').ToArray();
			if (tags.Length > 5)
			{
				ModelState.AddModelError("Tags", "You can only add up to 5 tags.");
				return View(course);
			}
			course.Tags = string.Join(",", tags.Take(5));

			if (image != null && image.Length > 0)
			{
				var fileName = Path.GetFileName(image.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CourseImages", fileName);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					image.CopyTo(stream);
				}
				course.CourseImage = fileName;
			}

			_dbContext.Courses.Add(course);
			_dbContext.SaveChanges();

			return RedirectToAction("Index");
		}


	}
}
