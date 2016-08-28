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
    public class UserProfile
    {
        string _userName;
        string _profilePicID;

        public UserProfile() { }
        public UserProfile(string userName, string profilePicID)
        {
            _userName = userName;
            _profilePicID = profilePicID;
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string ProfilePicID
        {
            get { return _profilePicID; }
            set { _profilePicID = value; }
        }
    }
}