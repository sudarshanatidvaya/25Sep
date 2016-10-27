using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Data.SqlClient;
using System.Data;

namespace Auradies
{
    public class DBRepository
    {

        string connectionString;


        public DBRepository()
        {
            connectionString = "Data Source=supriya.cytrfd6vhppk.us-west-2.rds.amazonaws.com;Initial Catalog=Auradies;Integrated Security=False;User ID=sa;Password=supriya21;";
        }


        #region Get queries

        public List<NewsFeed> GetAllActiveNewsFeeds()
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_GetAllActiveNewsFeed", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<NewsFeed> newsFeeds = new List<NewsFeed>();

                while (reader.Read())
                {
                    NewsFeed newsFeed = new NewsFeed();
                    newsFeed.ID = Convert.ToInt32(reader.GetValue(0));
                    newsFeed.UserProfileName = reader.GetValue(1).ToString();
                    newsFeed.UserProfilePicID = reader.GetValue(2).ToString();
                    newsFeed.StatusMessage = reader.GetValue(3).ToString();
                    newsFeed.NewsImage = reader.GetValue(4).ToString();
                    newsFeed.LinkText = reader.GetValue(5).ToString();
                    newsFeed.TimeStamp = Convert.ToDateTime(reader.GetValue(6)).ToString();
                    newsFeed.IsActive = Convert.ToBoolean(reader.GetValue(7));

                    newsFeeds.Add(newsFeed);
                }

                return newsFeeds;
            }
            catch (Exception ex)
            {
                return new List<NewsFeed>();
            }
            finally
            {
                myConnection.Close();
            }

        }

        public List<NewsFeedComment> GetAllActiveCommentsById(int newsFeedID)
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_GetAllActiveCommentsById", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NewsFeedID", SqlDbType.Int).Value = newsFeedID;

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<NewsFeedComment> comments = new List<NewsFeedComment>();

                while (reader.Read())
                {
                    NewsFeedComment comment = new NewsFeedComment();
                    comment.ID = Convert.ToInt32(reader.GetValue(0));
                    comment.NewsFeedID = Convert.ToInt32(reader.GetValue(1));
                    comment.UserName = reader.GetValue(2).ToString();
                    comment.UserImageID = reader.GetValue(3).ToString();
                    comment.Comment = reader.GetValue(4).ToString();
                    comment.CommentDateTime = Convert.ToDateTime(reader.GetValue(5)).ToString();
                    comment.IsActive = Convert.ToBoolean(reader.GetValue(6));

                    comments.Add(comment);
                }

                return comments;
            }

            catch (Exception ex)
            {
                return new List<NewsFeedComment>();
            }
            finally
            {
                myConnection.Close();
            }

        }


        public List<Contact> GetAllActiveContacts()
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_GetAllActiveContacts", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<Contact> contacts = new List<Contact>();

                while (reader.Read())
                {
                    Contact contact = new Contact();
                    contact.ID = Convert.ToInt32(reader.GetValue(0));
                    contact.ContactName = reader.GetValue(1).ToString();
                    contact.Designation = reader.GetValue(2).ToString();
                    contact.ContactNumber = reader.GetValue(3).ToString();
                    contact.Category = reader.GetValue(4).ToString();
                    contact.EmailID = reader.GetValue(5).ToString();
                    contact.OfficeAddress = reader.GetValue(6).ToString();
                    contact.ImageID = reader.GetValue(7).ToString();
                    contact.IsActive = Convert.ToBoolean(reader.GetValue(8));

                    contacts.Add(contact);
                }

                return contacts;

            }


            catch (Exception ex)
            {
                return new List<Contact>();
            }
            finally
            {
                myConnection.Close();
            }

        }
        #endregion


        #region Update Inactivity

        public void UpdateNewsFeedInactivityById(int newsFeedID)
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_UpdateNewsFeedInactiveById", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = newsFeedID;

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


        public void UpdateContactInactiveById(int contactID)
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_UpdateContactInactiveById", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = contactID;

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

        #endregion


        #region Inserting Queries




        public void SaveNewsFeed(NewsFeed newsFeed)
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_SaveNewsFeed", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = newsFeed.UserProfileName;
                cmd.Parameters.Add("@UserImageID", SqlDbType.NVarChar).Value = newsFeed.UserProfilePicID;
                cmd.Parameters.Add("@StatusMessage", SqlDbType.NVarChar).Value = newsFeed.StatusMessage;
                cmd.Parameters.Add("@StatusImageID", SqlDbType.NVarChar).Value = newsFeed.NewsImage;
                cmd.Parameters.Add("@StatusLink", SqlDbType.NVarChar).Value = newsFeed.LinkText;
                cmd.Parameters.Add("@StatusDateTime", SqlDbType.DateTime).Value = DateTime.Now.ToString();
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = newsFeed.IsActive;

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

        public void SaveNewsFeedComment(NewsFeedComment newsFeedComment)
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_SaveNewsFeedComment", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NewsFeedID", SqlDbType.Int).Value = newsFeedComment.NewsFeedID;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = newsFeedComment.UserName;
                cmd.Parameters.Add("@UserImageID", SqlDbType.NVarChar).Value = newsFeedComment.UserImageID;
                cmd.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = newsFeedComment.Comment;
                cmd.Parameters.Add("@CommentDateTime", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = newsFeedComment.IsActive;

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

        public void SaveContact(Contact contact)
        {
            SqlConnection myConnection = new SqlConnection();
            try
            {

                myConnection.ConnectionString = connectionString;

                SqlCommand cmd = new SqlCommand("p_SaveContact", myConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = contact.ContactName;
                cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = contact.Designation;
                cmd.Parameters.Add("@ContactNumber", SqlDbType.NVarChar).Value = contact.ContactNumber;
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = contact.Category;
                cmd.Parameters.Add("@MailID", SqlDbType.NVarChar).Value = contact.EmailID;
                cmd.Parameters.Add("@OfficeAddress", SqlDbType.NVarChar).Value = contact.OfficeAddress;
                cmd.Parameters.Add("@ImageID", SqlDbType.NVarChar).Value = contact.ImageID;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = contact.IsActive;

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

        #endregion
    }
}