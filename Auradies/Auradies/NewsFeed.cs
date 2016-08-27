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

namespace Auradies
{
    public class NewsFeed
    {
        string _userProfileName;
        string _userProfilePicID;
        string _timeStamp;
        string _statusMessage;
        string _linkText;
        string _newsImage;


        public NewsFeed() { }

        public NewsFeed(string userProfileName, string userProfilePicID, string timeStamp, string statusMessage, string linkText, string newsImage)
        {
            _userProfileName = userProfileName;
            _userProfilePicID = userProfilePicID;
            _timeStamp = timeStamp;
            _statusMessage = statusMessage;
            _linkText = linkText;
            _newsImage = newsImage;
        }

        public string UserProfileName
        {
            get { return _userProfileName; }
            set { _userProfileName = value; }
        }

        public string UserProfilePicID
        {
            get { return _userProfilePicID; }
            set { _userProfilePicID = value; }
        }

        public string TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; }
        }

        public string LinkText
        {
            get { return _linkText; }
            set { _linkText = value; }
        }

        public string NewsImage
        {
            get { return _newsImage; }
            set { _newsImage = value; }
        }

    }
}