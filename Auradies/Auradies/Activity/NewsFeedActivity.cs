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
using Android.Content.PM;
using Newtonsoft.Json;

namespace Auradies
{
    [Activity(Label = "NewsFeedActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class NewsFeedActivity : Activity
    {

        private ListView _listView;
        List<NewsFeed> newsFeeds = new List<NewsFeed>();
        private UserProfile _loggedInUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewsFeedLayout);

            _listView = FindViewById<ListView>(Resource.Id.NewsFeedListView);

            _loggedInUser = new UserProfile();

            newsFeeds = JsonConvert.DeserializeObject<List<NewsFeed>>(Intent.GetStringExtra("AllNewsFeeds"));
            _loggedInUser = JsonConvert.DeserializeObject<UserProfile>(Intent.GetStringExtra("loggedInUser"));

            NewsFeedAdapter newsFeedAdapter = new NewsFeedAdapter(this, newsFeeds);

            _listView.Adapter = newsFeedAdapter;

            _listView.ItemClick += _listView_ItemClick;
        }

        private void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            NewsFeed newsFeed = newsFeeds[e.Position];


            Intent intent = new Intent(this, typeof(NewsFeedDetailActivity));
            intent.PutExtra("SelectedNewsFeed", JsonConvert.SerializeObject(newsFeed));
            intent.PutExtra("loggedInUser", JsonConvert.SerializeObject(_loggedInUser));

            this.StartActivity(intent);

        }
    }
}