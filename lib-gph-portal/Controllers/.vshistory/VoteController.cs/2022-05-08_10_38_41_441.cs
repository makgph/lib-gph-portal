using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using sa.gov.libgph.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace sa.gov.libgph.Controllers
{
    public class VoteController : SurfaceController
    {

        // GET: Vote
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SubmitVote(string vote)
        {

            VoteResult voteResults = GetVotesCount();
            if (vote != null)
            {

                string cookie = GetFromCookie("lib_Vote", "vote");
                if (cookie == null)
                {
                    StoreInCookie("lib_Vote", Request.Url.Host, "vote", vote, DateTime.Now.AddDays(15));
                    RecordVote(vote);
                    voteResults = GetVotesCount();

                }



            }


        }


        public void StoreInCookie(string cookieName, string cookieDomain, string keyName, string value, DateTime? expirationDate, bool httpOnly = true)
        {
            // NOTE: we have to look first in the response, and then in the request.
            // This is required when we update multiple keys inside the cookie.
            HttpCookie cookie = HttpContext.Response.Cookies[cookieName] ?? HttpContext.Request.Cookies[cookieName];
            if (cookie == null) cookie = new HttpCookie(cookieName);
            if (!String.IsNullOrEmpty(keyName)) cookie.Values.Set(keyName, value);
            else cookie.Value = value;
            if (expirationDate.HasValue) cookie.Expires = expirationDate.Value;
            if (!String.IsNullOrEmpty(cookieDomain)) cookie.Domain = cookieDomain;
            // secure false for local
            cookie.Secure = true;
            cookie.HttpOnly = true;
            //if (httpOnly) cookie.HttpOnly = true;
            HttpContext.Response.Cookies.Set(cookie);

        }

        public string GetFromCookie(string cookieName, string keyName)
        {
            HttpCookie cookie = HttpContext.Request.Cookies[cookieName];
            if (cookie != null)
            {
                string val = (!String.IsNullOrEmpty(keyName)) ? cookie[keyName] : cookie.Value;
                if (!String.IsNullOrEmpty(val)) return Uri.UnescapeDataString(val);
            }
            return null;
        }


        public static void RecordVote(string vote)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("record_vote", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("vote_label", System.Data.SqlDbType.NVarChar).Value = vote;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public static VoteResult GetVotesCount()
        {
            VoteResult voteRes = new VoteResult();
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString))
            {
                //string  queryString = " SELECT vote_count FROM vote WHERE vote_label = 'Excellent'"

                using (SqlCommand cmd = new SqlCommand("get_votes_count", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    var result = new DataSet();
                    var dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(result);

                    if (result != null)
                    {
                        voteRes.BadCount = int.Parse(result.Tables[0].Rows[0][0].ToString());
                        voteRes.GoodCount = int.Parse(result.Tables[1].Rows[0][0].ToString());
                        voteRes.ExcellentCount = int.Parse(result.Tables[2].Rows[0][0].ToString());

                    }
                    conn.Close();

                }
            }
            return voteRes;
        }
    }

}