using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient; 
using System.Data;
using CattoIMGApi.Functions;
    
namespace CattoIMGApi.Controllers
{
    [ApiController]
    public class ApiUrls : Controller
    {

        [Route("/api/getUser/")]
        public ActionResult AllVersions(string username)
        {
            MySQLData mySQLData = new MySQLData(); // Load CattoIMGApi.Functions.MySQLData Variables      

            DataTable dt = new DataTable();

            var data = new List<Models.userData>();
            var con = new MySqlConnection(mySQLData.mysqlConnection);
            
            con.Open();

            using (MySqlCommand cmd = new MySqlCommand("SELECT username, rankId FROM userData WHERE username = @UserName;", con))
            {
                cmd.Parameters.AddWithValue("@UserName", username);

                dt.Load(cmd.ExecuteReader());
            };

            foreach (DataRow row in dt.Rows)
            {
                string[] ranks = { "Member", "Developer", "Owner" };

                #pragma warning disable CS8604 
                var rank = Int32.Parse(row[1].ToString());

                data.Add(new Models.userData { Username = row[0].ToString(), Rank = $"{ranks[rank]}", UserBio = "Feature soon." });
            }

            return Json(data);
        }
    }
}
