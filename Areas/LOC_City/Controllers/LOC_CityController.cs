using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApplication4.Areas.LOC_City.Models;
using System.Reflection;

namespace WebApplication4.Areas.LOC_City.Controllers
{
	[Area("LOC_City")]
	[Route("LOC_City/LOC_City/{Action}")]
	public class LOC_CityController : Controller
	{
		private readonly IConfiguration Configuration;
		public LOC_CityController(IConfiguration _configuration)
		{
			Configuration = _configuration;
		}

		public IActionResult LOC_CityList()
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_SelectAll";
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
		}

		public IActionResult LOC_CitySearch(string CityName, string CityCode) 
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_LOC_City_Search";
			cmd.Parameters.AddWithValue("@CityName", CityName);
			cmd.Parameters.AddWithValue("@CityCode", CityCode);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return RedirectToAction("LOC_CityList", dt);
		}

		[Area("LOC_City")]
		[Route("LOC_City/LOC_City/{Action}")]
		public IActionResult LOC_CitySearchData(LOC_CityModal modal) 
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_LOC_City_Search";
			cmd.Parameters.AddWithValue("CityName", modal.CityName);
			cmd.Parameters.AddWithValue("CityCode", modal.CityCode);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
		}

		[Area("LOC_City")]
		[Route("LOC_City/LOC_City/{Action}")]
		public IActionResult LOC_CityAdd()
		{
			return View();
		}

		[Area("LOC_City")]
		[Route("LOC_City/LOC_City/{Action}")]
		public IActionResult LOC_CityAddFormPage(LOC_CityModal modal)
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_Insert";
			cmd.Parameters.AddWithValue("CityName", modal.CityName);
			cmd.Parameters.AddWithValue("CityCode", modal.CityCode);
			cmd.Parameters.AddWithValue("StateID", modal.StateID);
			cmd.Parameters.AddWithValue("CountryID", modal.CountryID);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_CityList");
		}

		[Area("LOC_City")]
		[Route("LOC_City/LOC_City/{Action}")]
		public IActionResult LOC_CityEdit(int CityID) 
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_SelectByPK";
			cmd.Parameters.AddWithValue("CityID", CityID);
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			string CityName = dt.Rows[0]["CityName"].ToString();
			string CityCode = dt.Rows[0]["CityCode"].ToString();
			string StateID = dt.Rows[0]["StateID"].ToString();
			string CountryID = dt.Rows[0]["CountryID"].ToString();
			ViewBag.CityID = CityID;
			ViewBag.CityName = CityName;
			ViewBag.CityCode = CityCode;
			ViewBag.StateID = StateID;
			ViewBag.CountryID = CountryID;
			return View();
		}

		[Area("LOC_City")]
		[Route("LOC_City/LOC_City/{Action}")]
		public IActionResult LOC_CityUpdateFillFormData(LOC_CityModal modal) 
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_UpdateByPK";
			cmd.Parameters.AddWithValue("CityID", modal.CityID);
			cmd.Parameters.AddWithValue("CityName", modal.CityName);
			cmd.Parameters.AddWithValue("StateID", modal.StateID);
			cmd.Parameters.AddWithValue("CityCode", modal.CityCode);
			cmd.Parameters.AddWithValue("CountryID", modal.CountryID);
			cmd.ExecuteNonQuery();
			return RedirectToAction("LOC_CityList");
		}

		[Area("LOC_City")]
		[Route("LOC_City/LOC_City/{Action}")]
		public IActionResult LOC_CityDelete(int CityID) 
		{
			string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_City_DeleteByPK";
			cmd.Parameters.AddWithValue("CityID", CityID);
			cmd.ExecuteNonQuery();
			conn.Close();
			return RedirectToAction("LOC_CityList");
		}
	}
}