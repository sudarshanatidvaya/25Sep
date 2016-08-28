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
using Square.Picasso;
using Android.Content.PM;
using Newtonsoft.Json;

namespace Auradies
{
    [Activity(Label = "HomeActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class HomeActivity : Activity
    {
        private ImageView _profilePic;
        private TextView textWelcomeUser;
        private ImageButton _btnNews;
        private ImageButton _btnGallery;
        private ImageButton _btnEvents;
        private ImageButton _btnContacts;
        private UserProfile _loggedInUser;
        
        bool doubleBackToExitPressedOnce = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                SetContentView(Resource.Layout.HomeLayout);


                // Create your application here

                _profilePic = FindViewById<ImageView>(Resource.Id.userImage);
                textWelcomeUser = FindViewById<TextView>(Resource.Id.textWelcomeUser);
                _btnNews = FindViewById<ImageButton>(Resource.Id.btnNews);
                _btnGallery = FindViewById<ImageButton>(Resource.Id.btnGallery);
                _btnEvents = FindViewById<ImageButton>(Resource.Id.btnEvents);
                _btnContacts = FindViewById<ImageButton>(Resource.Id.btnContacts);
                _loggedInUser = new UserProfile();

                _loggedInUser = JsonConvert.DeserializeObject<UserProfile>(Intent.GetStringExtra("loggedInUser"));

                //string imageUrl = Intent.GetStringExtra("ProfilePicID");
                //string name = Intent.GetStringExtra("UserName");

                string imageUrl = _loggedInUser.ProfilePicID;
                string name = _loggedInUser.UserName;


                Picasso.With(this).Load(imageUrl).Into(_profilePic);


                textWelcomeUser.Text = String.Format("Hi {0}, Welcome to the world of Auradies!", name);

                //var gridview = FindViewById<GridView>(Resource.Id.gridview);
                //gridview.Adapter = new GridImageAdapter(this);

                //gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                //    Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();
                //};


                _btnNews.Click += _btnNews_Click;
            }
            catch (Exception ex)
            {

            }
        }

        private void _btnNews_Click(object sender, EventArgs e)
        {
            List<NewsFeed> newsFeeds = TestReturnNewsFeed(_loggedInUser);

            Intent intent = new Intent(this, typeof(NewsFeedActivity));
            intent.PutExtra("AllNewsFeeds", JsonConvert.SerializeObject(newsFeeds));

            this.StartActivity(intent);
            //this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        private List<NewsFeed> TestReturnNewsFeed(UserProfile loggedInUser)
        {
            NewsFeed newsFeed01 = new NewsFeed("TIME", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");


            NewsFeed newsFeed02 = new NewsFeed("TIME2", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");


            NewsFeed newsFeed03 = new NewsFeed("TIME3", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");


            NewsFeed newsFeed04 = new NewsFeed("TIME4", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");


            NewsFeed newsFeed05 = new NewsFeed("TIME5", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");


            NewsFeed newsFeed06 = new NewsFeed("TIME6", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");


            NewsFeed newsFeed07 = new NewsFeed("TIME7", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");


            NewsFeed newsFeed08 = new NewsFeed("TIME8", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
                DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "hhttp://api.androidhive.info/feed/img/time_best.jpg");

            List<NewsFeed> newsFeeds = new List<NewsFeed>();
            newsFeeds.Add(newsFeed01);
            newsFeeds.Add(newsFeed02);
            newsFeeds.Add(newsFeed03);
            newsFeeds.Add(newsFeed04);
            newsFeeds.Add(newsFeed05);
            newsFeeds.Add(newsFeed06);
            newsFeeds.Add(newsFeed07);
            newsFeeds.Add(newsFeed08);

            return newsFeeds;

        }

        public override void OnBackPressed()
        {
            if (doubleBackToExitPressedOnce)
            {
                //base.OnBackPressed();
                //Java.Lang.JavaSystem.Exit(0);
                this.Finish();
                //Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                return;
            }


            this.doubleBackToExitPressedOnce = true;
            Toast.MakeText(this, "Please click BACK again to exit", ToastLength.Short).Show();

            new Handler().PostDelayed(() =>
            {
                doubleBackToExitPressedOnce = false;
            }, 2000);


            //this.doubleBackToExitPressedOnce = true;
            //Toast.MakeText(this, "Please click BACK again to exit", ToastLength.Short).Show();
            //(new Handler() + postDelayed(new Runnable(), 2000));
        }

        public override void Finish()
        {
            Process.KillProcess(Process.MyPid());
        }

    }
}