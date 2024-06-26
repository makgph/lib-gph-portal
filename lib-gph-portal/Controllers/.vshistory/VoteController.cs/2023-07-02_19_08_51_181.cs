﻿using sa.gov.libgph.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class VoteController : SurfaceController
    {

        // GET: Vote
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult SubmitVote(string vote)
        {
            bool isNewRecordVote = false;

            VoteResult voteResults = GetVotesCount();
            if (vote != null)
            {

                string cookie = GetFromCookie("lib_Vote", "vote");
                if (cookie == null)
                {
                    isNewRecordVote = RecordVote(vote);
                    if (isNewRecordVote)
                    {
                        StoreInCookie("lib_Vote", Request.Url.Host, "vote", vote, DateTime.Now.AddDays(15));
                    }
                    voteResults = GetVotesCount();
                }


            }

            return Json(isNewRecordVote, JsonRequestBehavior.AllowGet);

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


        public static bool RecordVote(string vote)
        {
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString))
            {
                var ipAddress = getCurrentIpAddress();
                var sessionId = "sessionId";
                using (SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM visitorData WHERE IPAddress = @ipAddress) INSERT INTO visitorData (IPAddress, SessionID) VALUES (@ipAddress, @sessionId)", conn))
                {
                    cmd.Parameters.AddWithValue("@ipAddress", ipAddress);
                    cmd.Parameters.AddWithValue("@sessionId", sessionId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        // The data was inserted successfully
                        using (SqlCommand cmd2 = new SqlCommand("record_vote", conn))
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.Add("vote_label", SqlDbType.NVarChar).Value = vote;
                            conn.Open();
                            cmd2.ExecuteNonQuery();
                            conn.Close();
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                        // A record with the same ipAddress already exists
                    }
                }

            }
        }
        public static VoteResult GetVotesCount()
        {
            VoteResult voteRes = new VoteResult();
            using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString))
            {
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

        private static string getCurrentIpAddress()
        {
            string ipAddress = "";
            string apiGetter = ConfigurationManager.ConnectionStrings["IPAddressAPIGetter"].ToString();
            WebRequest request = WebRequest.Create(apiGetter);
            using (WebResponse response = request.GetResponse())
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                ipAddress = streamReader.ReadToEnd();
            }
            return ipAddress;
        }
    }

}