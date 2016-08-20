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
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        private ImageView _profilePic;
        private TextView textWelcomeUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HomeLayout);


            // Create your application here

            _profilePic = FindViewById<ImageView>(Resource.Id.userImage);
            textWelcomeUser = FindViewById<TextView>(Resource.Id.textWelcomeUser);

            //loggedOnUser = JsonConvert.DeserializeObject<Profile>("UserProfile");

            string imageUrl = Intent.GetStringExtra("ProfilePicID");
            _profilePic.SetImageResource(imageUrl);
            string name = Intent.GetStringExtra("UserName");
            textWelcomeUser.Text = String.Format("Hi {0}, Welcome to the world of Auradies!", name);

        }
    }
}