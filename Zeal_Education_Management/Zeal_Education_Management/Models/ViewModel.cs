namespace Zeal_Education_Management.Models
{
	public class ViewModel
	{
		public List<JobModel> Jobs { get; set; }
		public JobApplicationModel? JobApplication { get; set; }

		public List<CourseModel> Courses { get; set; }
		public CourseApplicationModel? CourseApplication { get; set; }

	}
}
