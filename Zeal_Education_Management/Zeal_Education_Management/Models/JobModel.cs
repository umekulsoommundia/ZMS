using System.ComponentModel.DataAnnotations;

namespace Zeal_Education_Management.Models
{
	public class JobModel
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Designation { get; set; }

		public string Qualifications { get; set; }

		public string Location { get; set; }


	}
}
