using AuradiesShared;
using System.Collections.Generic;

namespace TestAPI
{
    public class NewsFeedService
    {
        DBRepository dbconn;
        public NewsFeedService()
        {
            dbconn = new DBRepository();
        }
        public List<NewsFeed> GetActiveNewsFeeds()
        {
            List<NewsFeed> newsFeeds = new List<NewsFeed>();
            //DBRepository dbconn = new DBRepository();

            newsFeeds = dbconn.GetAllActiveNewsFeeds();

            return (newsFeeds == null) ? new List<NewsFeed>() : newsFeeds;
        }

        public List<NewsFeedComment> GetAllActiveCommentsById(int newsFeedID)
        {
            List<NewsFeedComment> comments = new List<NewsFeedComment>();
            //DBRepository dbconn = new DBRepository();

            comments = dbconn.GetAllActiveCommentsById(newsFeedID);

            return (comments == null) ? new List<NewsFeedComment>() : comments;
        }

        public void UpdateNewsFeedInactivityById(int newsFeedID)
        {
            dbconn.UpdateNewsFeedInactivityById(newsFeedID);
            //return (comments == null) ? new List<NewsFeedComment>() : comments;
        }
    }
}