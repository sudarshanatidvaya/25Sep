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
        private DBRepository dbRepository;
        
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

                dbRepository = new DBRepository();

                _btnNews.Click += _btnNews_Click;
                _btnContacts.Click += _btnContacts_Click;
            }
            catch (Exception ex)
            {

            }
        }

        private void _btnContacts_Click(object sender, EventArgs e)
        {
            List<Contact> contacts = TestReturnContact();

            Intent intent = new Intent(this, typeof(ContactActivity));
            intent.PutExtra("AllContacts", JsonConvert.SerializeObject(contacts));

            this.StartActivity(intent);
        }

        private List<Contact> TestReturnContact()
        {
            Contact contact01 = new Contact(1, "Aurades", "Group Name", "9876543210", "asd@dasasd.com", "FB Page", "", "", true);
            Contact contact02 = new Contact(2, "Raju", "Engineer", "1234567890", "rajuasd@dasasd.com", "General", "", "", true);

            List<Contact> contacts = new List<Contact>();

            contacts.Add(contact01);
            contacts.Add(contact02);

            return contacts;
        }

        private void _btnNews_Click(object sender, EventArgs e)
        {
            List<NewsFeed> newsFeeds = TestReturnNewsFeed(_loggedInUser);

            Intent intent = new Intent(this, typeof(NewsFeedActivity));
            intent.PutExtra("AllNewsFeeds", JsonConvert.SerializeObject(newsFeeds));
            intent.PutExtra("loggedInUser", JsonConvert.SerializeObject(_loggedInUser));

            this.StartActivity(intent);
            //this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);
        }

        private List<NewsFeed> TestReturnNewsFeed(UserProfile loggedInUser)
        {


            List<NewsFeed> newsFeeds = dbRepository.GetAllActiveNewsFeeds();


            return newsFeeds;









            //NewsFeed newsFeed01 = new NewsFeed("TIME", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos", "http://ti.me/1qW8MLB", "http://api.androidhive.info/feed/img/time_best.jpg");


            //NewsFeed newsFeed02 = new NewsFeed("Auradies", "https://scontent.fblr1-1.fna.fbcdn.net/v/t1.0-9/12036390_557267667754636_3335132799840661229_n.jpg?oh=d725aa85947f474517a0ac680e389094&oe=585393D8", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "Aerial view of our Aurad", "https://www.facebook.com/DashingAuradies/photos/a.110249912456416.19511.110243789123695/557267941087942/?type=3&theater", "https://scontent.fblr1-1.fna.fbcdn.net/v/t1.0-9/304432_132404483574292_1016404272_n.png?oh=651dc007ab81923f1482eb812f43db25&oe=585374AC");


            //NewsFeed newsFeed03 = new NewsFeed("TIME3", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "http://api.androidhive.info/feed/img/time_best.jpg");


            //NewsFeed newsFeed04 = new NewsFeed("TIME4", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "http://api.androidhive.info/feed/img/time_best.jpg");


            //NewsFeed newsFeed05 = new NewsFeed("TIME5", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "http://api.androidhive.info/feed/img/time_best.jpg");


            //NewsFeed newsFeed06 = new NewsFeed("TIME6", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "http://api.androidhive.info/feed/img/time_best.jpg");


            //NewsFeed newsFeed07 = new NewsFeed("TIME7", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "http://api.androidhive.info/feed/img/time_best.jpg");


            //NewsFeed newsFeed08 = new NewsFeed("TIME8", "http://api.androidhive.info/feed/img/time.png", loggedInUser.UserName, loggedInUser.ProfilePicID,
            //    DateTime.Now.ToString(), "30 years of Cirque du Soleil's best photos2222", "http://ti.me/1qW8MLB", "http://api.androidhive.info/feed/img/time_best.jpg");

            //List<NewsFeed> newsFeeds = new List<NewsFeed>();
            //newsFeeds.Add(newsFeed01);
            //newsFeeds.Add(newsFeed02);
            //newsFeeds.Add(newsFeed03);
            //newsFeeds.Add(newsFeed04);
            //newsFeeds.Add(newsFeed05);
            //newsFeeds.Add(newsFeed06);
            //newsFeeds.Add(newsFeed07);
            //newsFeeds.Add(newsFeed08);

            //return newsFeeds;

        }

        public override void OnBackPressed()
        {
            if (doubleBackToExitPressedOnce)
            {
                this.FinishAffinity();
                return;
            }

            this.doubleBackToExitPressedOnce = true;
            Toast.MakeText(this, "Please click BACK again to exit", ToastLength.Short).Show();

            new Handler().PostDelayed(() =>
            {
                doubleBackToExitPressedOnce = false;
            }, 2000);

        }

        public override void FinishAffinity()
        {
            base.FinishAffinity();
            Process.KillProcess(Process.MyPid());
            
        }
    }
}