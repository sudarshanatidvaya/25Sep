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
using Newtonsoft.Json;
using Square.Picasso;

namespace Auradies
{
    [Activity(Label = "NewsFeedDetailActivity")]
    public class NewsFeedDetailActivity : Activity
    {
        private TextView _user;
        private TextView _timeStamp;
        private TextView _statusMessage;
        private TextView _linkMessage;
        private ImageView _userImage;
        private ImageView _userPostImage;
        private NewsFeed _newsFeed;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewsFeedDetailLayout);


            _newsFeed = JsonConvert.DeserializeObject<NewsFeed>(Intent.GetStringExtra("SelectedNewsFeed"));

            _user = FindViewById<TextView>(Resource.Id.textViewUserProfileName);
            _timeStamp = FindViewById<TextView>(Resource.Id.textViewUserTimeStamp);
            _statusMessage = FindViewById<TextView>(Resource.Id.textViewUserPostStatus);
            _linkMessage = FindViewById<TextView>(Resource.Id.textViewUserPostLink);
            _userImage = FindViewById<ImageView>(Resource.Id.imageViewFeedUser);
            _userPostImage = FindViewById<ImageView>(Resource.Id.imageViewUserPostImage);


            _user.Text = _newsFeed.UserProfileName;
            _timeStamp.Text = _newsFeed.TimeStamp;
            _statusMessage.Text = _newsFeed.StatusMessage;
            _linkMessage.Text = _newsFeed.LinkText;

            Picasso.With(this).Load(_newsFeed.UserProfilePicID).Into(_userImage);
            Picasso.With(this).Load(_newsFeed.NewsImage).Into(_userPostImage);
        }
    }
}