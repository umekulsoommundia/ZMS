using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zeal_Education_Management.Models
{
	public class JobApplicationModel
	{
		[Key]
		public int Id { get; set; }


		public string? Name { get; set; }


		public string? Email { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Profession { get; set; }

		public string? Qualifications { get; set; }
		[NotMapped]
		public IFormFile ImageFile { get; set; }

		public byte[] Image { get; set; }

		[NotMapped]
		public IFormFile ResumeFile { get; set; }

		public byte[] Resume { get; set; }

		public int JobId { get; set; }

		[ForeignKey("JobId")]
		public JobModel id { get; set; }

	}
}

