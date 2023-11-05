using System.ComponentModel.DataAnnotations;

namespace Zeal_Education_Management.Models
{
	public class InstructorModel
	{

		[Key]
		public int Id { get; set; }


		public string Name { get; set; }


		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string Profession { get; set; }

		public string Qualifications { get; set; }

		public string ResumePath { get; set; }

		public string ImagePath { get; set; }

	}
}
