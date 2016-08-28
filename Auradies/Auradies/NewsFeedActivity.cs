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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewsFeedLayout);

            _listView = FindViewById<ListView>(Resource.Id.NewsFeedListView);

            List<NewsFeed> newsFeeds = new List<NewsFeed>();

            newsFeeds = JsonConvert.DeserializeObject<List<NewsFeed>>(Intent.GetStringExtra("AllNewsFeeds"));

            NewsFeedAdapter newsFeedAdapter = new NewsFeedAdapter(this, newsFeeds);

            _listView.Adapter = newsFeedAdapter;
        }
    }
}