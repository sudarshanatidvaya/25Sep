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
            }
            catch (Exception ex)
            {

            }
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