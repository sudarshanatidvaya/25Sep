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
        private EditText _newComment;
        private Button _btnSubmit;
        private NewsFeed _newsFeed;
        private UserProfile _loggedInUser;

        private ListView _listView;
        List<NewsFeedComment> newsFeedComments = new List<NewsFeedComment>();
        private DBRepository dbRepository;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewsFeedDetailLayout);

            dbRepository = new DBRepository();
            _listView = FindViewById<ListView>(Resource.Id.CommentsListView);

            _loggedInUser = new UserProfile();

            _newsFeed = JsonConvert.DeserializeObject<NewsFeed>(Intent.GetStringExtra("SelectedNewsFeed"));
            _loggedInUser = JsonConvert.DeserializeObject<UserProfile>(Intent.GetStringExtra("loggedInUser"));

            _user = FindViewById<TextView>(Resource.Id.textViewUserProfileName);
            _timeStamp = FindViewById<TextView>(Resource.Id.textViewUserTimeStamp);
            _statusMessage = FindViewById<TextView>(Resource.Id.textViewUserPostStatus);
            _linkMessage = FindViewById<TextView>(Resource.Id.textViewUserPostLink);
            _userImage = FindViewById<ImageView>(Resource.Id.imageViewFeedUser);
            _userPostImage = FindViewById<ImageView>(Resource.Id.imageViewUserPostImage);
            _newComment = FindViewById<EditText>(Resource.Id.editTextNewComment);
            _btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);


            _user.Text = _newsFeed.UserProfileName;
            _timeStamp.Text = _newsFeed.TimeStamp;
            _statusMessage.Text = _newsFeed.StatusMessage;
            _linkMessage.Text = _newsFeed.LinkText;

            Picasso.With(this).Load(_newsFeed.UserProfilePicID).Into(_userImage);
            Picasso.With(this).Load(_newsFeed.NewsImage).Into(_userPostImage);


            newsFeedComments = GetComments(_newsFeed.ID);
            if (newsFeedComments.Count > 0)
            {
                CommentAdapter newsFeedAdapter = new CommentAdapter(this, newsFeedComments);

                _listView.Adapter = newsFeedAdapter;
            }

            _btnSubmit.Click += _btnSubmit_Click;

        }

        private void _btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_newComment.Text == string.Empty)
                {
                    return;
                }
                NewsFeedComment comment = new NewsFeedComment()
                {
                    ID = 0,
                    NewsFeedID = _newsFeed.ID,
                    UserName = _loggedInUser.UserName,
                    UserImageID = (_loggedInUser.ProfilePicID == null) ? string.Empty : _loggedInUser.ProfilePicID,
                    Comment = _newComment.Text,
                    CommentDateTime = DateTime.Now.ToString(),
                    IsActive = true
                };

                dbRepository.SaveNewsFeedComment(comment);
                RefreshComments(_newsFeed.ID);
            }
            catch (Exception ex)
            {
            }

        }

        private void RefreshComments(int iD)
        {
            _newComment.Text = string.Empty;
            newsFeedComments = GetComments(iD);

            CommentAdapter newsFeedAdapter = new CommentAdapter(this, newsFeedComments);

            _listView.Adapter = newsFeedAdapter;
        }

        private List<NewsFeedComment> GetComments(int iD)
        {
            try
            {
                return dbRepository.GetAllActiveCommentsById(iD);
            }
            catch (Exception ex)
            {
                return new List<NewsFeedComment>();
            }
        }
    }
}