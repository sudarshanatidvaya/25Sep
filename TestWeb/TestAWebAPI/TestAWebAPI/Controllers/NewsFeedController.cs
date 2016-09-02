using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestAWebAPI.Models;

namespace TestAWebAPI.Controllers
{
    [RoutePrefix("api/News")]
    public class NewsFeedController : ApiController
    {
        [Route("Get/{1}")]
        public NewsFeed Get(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            SqlCommand cmd = new SqlCommand("p_GetNewsFeedById", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            
            NewsFeed newsFeed = new NewsFeed();
            try
            {
                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    newsFeed = new NewsFeed();
                    newsFeed.ID = Convert.ToInt32(reader.GetValue(0));
                    newsFeed.UserProfileName = reader.GetValue(1).ToString();
                    newsFeed.UserProfilePicID = reader.GetValue(2).ToString();
                    newsFeed.StatusMessage = reader.GetValue(3).ToString();
                    newsFeed.NewsImage = reader.GetValue(4).ToString();
                    newsFeed.LinkText = reader.GetValue(5).ToString();
                    newsFeed.TimeStamp = Convert.ToDateTime(reader.GetValue(6)).Ticks.ToString();
                    newsFeed.IsActive = Convert.ToBoolean(reader.GetValue(7));
                }
                return newsFeed;
            }
            catch (Exception ex)
            {
                return new NewsFeed();
            }
            finally
            {
                myConnection.Close();
            }
        }


        [HttpPost]
        [Route("PostNewsFeed")]
        public void Post(NewsFeed newsFeed)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            newsFeed = new NewsFeed(2, "admin2", "some Image ID", "user", "some imageid again", DateTime.Now.ToString(), "ola ola ola", "linkkk", "imageeee", true);
            
            

            SqlCommand cmd = new SqlCommand("p_SaveNewsFeed", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = newsFeed.UserProfileName;
            cmd.Parameters.Add("@UserImageID", SqlDbType.NVarChar).Value = newsFeed.UserProfilePicID;
            cmd.Parameters.Add("@StatusMessage", SqlDbType.NVarChar).Value = newsFeed.StatusMessage;
            cmd.Parameters.Add("@StatusImageID", SqlDbType.NVarChar).Value = newsFeed.NewsImage;
            cmd.Parameters.Add("@StatusLink", SqlDbType.NVarChar).Value = newsFeed.LinkText;
            cmd.Parameters.Add("@StatusDateTime", SqlDbType.DateTime).Value = newsFeed.TimeStamp;
            cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = newsFeed.IsActive;

            try
            {
                myConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}