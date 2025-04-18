namespace WebApplication4.Areas.MST_Student.Models
{
	public class MST_StudentModel
	{
		public int StudentID { get; set; }
		public int BranchID { get; set; }
		public int CityID { get; set; }
		public string StudentName { get; set; } = string.Empty;
		public string MobileNoStudent { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string MobileNoFather { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string BirthDate { get; set; } = string.Empty;
		public string Age { get; set; } = string.Empty;
		public string IsActive { get; set; } = string.Empty;
		public string Gender { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
