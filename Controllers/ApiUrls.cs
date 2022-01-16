using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using CattoIMGApi.Functions;

#pragma warning disable CS8604

namespace CattoIMGApi.Controllers
{
    [ApiController]
    public class ApiUrls : Controller
    {

        [Route("/api/getUser/")]
        public ActionResult AllVersions(string username)
        {
            DataTable dt = new DataTable();

            var data = new List<Models.userData>();
            var con = new MySqlConnection(new MySQLData().mysqlConnection);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT username, rankId FROM userData WHERE username = @UserName;", con);

            cmd.Parameters.AddWithValue("@UserName", username);

            dt.Load(cmd.ExecuteReader());
            
            foreach (DataRow row in dt.Rows)
            {
                string[] ranks = { "Member", "Developer", "Owner" };

                var rank = Int32.Parse(row[1].ToString());

                data.Add(new Models.userData { Username = row[0].ToString(), Rank = $"{ranks[rank]}", UserBio = "Feature soon." });
            }

            return Json(data);
        }
    }
}
