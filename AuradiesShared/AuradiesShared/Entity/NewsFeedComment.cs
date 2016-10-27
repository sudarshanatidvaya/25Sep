namespace AuradiesShared
{
    public class NewsFeedComment
    {
        int _id;
        int _newsFeedID;
        string _userName;
        string _userImageID;
        string _comment;
        string _commentDateTime;
        bool _isActive;

        public NewsFeedComment() { }

        public NewsFeedComment(int id, int newsFeedID, string userName, string userImageID, string comment, string commentDateTime, bool isActive)
        {
            _id = id;
            _newsFeedID = newsFeedID;
            _userName = userName;
            _userImageID = userImageID;
            _comment = comment;
            _commentDateTime = commentDateTime;
            _isActive = isActive;

        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int NewsFeedID
        {
            get { return _newsFeedID; }
            set { _newsFeedID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string UserImageID
        {
            get { return _userImageID; }
            set { _userImageID = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public string CommentDateTime
        {
            get { return _commentDateTime; }
            set { _commentDateTime = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }


    }
}