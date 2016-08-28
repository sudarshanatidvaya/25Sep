﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Android.Content.PM;
using Android.Gms.Plus;
using Android.Gms.Plus.Model.People;
using Android.Graphics;
using Android.Animation;
using Newtonsoft.Json;

namespace Auradies
{
    [Activity(Label = "Auradies", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity, IGoogleApiClientConnectionCallbacks, IGoogleApiClientOnConnectionFailedListener
    {
        private IGoogleApiClient mGoogleApiClient;
        private SignInButton mGoogleSignIn;

        private ConnectionResult mConnectionResult;

        private bool mIntentInProgress;
        private bool mSignInClicked;
        private bool mInfoPopulated;

        private TextView logoText;
        private TextView textAuradies;

        string userName;
        string userEmail;
        string userImageUrl;

        //private TextView mName;
        //private TextView mTagline;
        //private TextView mBraggingRights;
        //private TextView mGender;
        //private TextView mRelationship;

        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);

                // Get our button from the layout resource,
                // and attach an event to it

                mGoogleSignIn = FindViewById<SignInButton>(Resource.Id.sign_in_button);

                logoText = FindViewById<TextView>(Resource.Id.textLogoA);
                textAuradies = FindViewById<TextView>(Resource.Id.textAppName);

                logoText.SetShadowLayer(10, 0, 0, Color.Red);
                textAuradies.SetShadowLayer(20, 0, 0, Color.AntiqueWhite);

                //Animation for Logo
                var animation = ObjectAnimator.OfFloat(logoText, "rotationY", 0.0f, 720f);
                animation.SetDuration(2000);

                animation.Start();
                logoText.Click += delegate { animation.Start(); };

                //mName = FindViewById<TextView>(Resource.Id.txtName);
                //mTagline = FindViewById<TextView>(Resource.Id.txtTagLine);
                //mBraggingRights = FindViewById<TextView>(Resource.Id.txtBraggingRights);
                //mGender = FindViewById<TextView>(Resource.Id.txtGender);
                //mRelationship = FindViewById<TextView>(Resource.Id.txtRelationship);

                mGoogleSignIn.Click += mGoogleSignIn_Click;

                GoogleApiClientBuilder builder = new GoogleApiClientBuilder(this);
                builder.AddConnectionCallbacks(this);
                builder.AddOnConnectionFailedListener(this);
                builder.AddApi(PlusClass.API);
                builder.AddScope(PlusClass.ScopePlusProfile);
                builder.AddScope(PlusClass.ScopePlusLogin);

                //Build our IGoogleApiClient
                mGoogleApiClient = builder.Build();

                
            }
            catch (Exception ex)
            {

            }

        }

        void mGoogleSignIn_Click(object sender, EventArgs e)
        {
            //Fire sign in
            if (!mGoogleApiClient.IsConnecting)
            {
                mSignInClicked = true;
                ResolveSignInError();
            }
        }

        private void ResolveSignInError()
        {
            if (mGoogleApiClient.IsConnected)
            {
                //No need to resolve errors, already connected
                return;
            }

            if (mConnectionResult.HasResolution)
            {
                try
                {
                    mIntentInProgress = true;
                    StartIntentSenderForResult(mConnectionResult.Resolution.IntentSender, 0, null, 0, 0, 0);
                }

                catch (Android.Content.IntentSender.SendIntentException e)
                {
                    //The intent was cancelled before it was sent. Return to the default
                    //state and attempt to connect to get an updated ConnectionResult
                    mIntentInProgress = false;
                    mGoogleApiClient.Connect();
                }
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 0)
            {
                if (resultCode != Result.Ok)
                {
                    mSignInClicked = false;
                }

                mIntentInProgress = false;

                if (!mGoogleApiClient.IsConnecting)
                {
                    mGoogleApiClient.Connect();
                }
            }
        }


        protected override void OnStart()
        {
            base.OnStart();
            mGoogleApiClient.Connect();
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (mGoogleApiClient.IsConnected)
            {
                mGoogleApiClient.Disconnect();
            }
        }

        //Google plus login
        public void OnConnected(Bundle connectionHint)
        {
            //Successful log in hooray!!
            mSignInClicked = false;

            if (mInfoPopulated)
            {
                //No need to populate info again
                return;
            }

            if (PlusClass.AccountApi.GetAccountName(mGoogleApiClient)!=null)
            {
                userName = PlusClass.AccountApi.GetAccountName(mGoogleApiClient);
            }

            if (PlusClass.PeopleApi.GetCurrentPerson(mGoogleApiClient) != null)
            {
                IPerson plusUser = PlusClass.PeopleApi.GetCurrentPerson(mGoogleApiClient);

                if (plusUser.HasDisplayName)
                {
                    //mName.Text += plusUser.DisplayName;
                    userName = plusUser.DisplayName;
                }

                if (plusUser.HasImage)
                {
                    IPersonImage userImage = plusUser.Image;
                    if (userImage.HasUrl)
                    {
                        userImageUrl = userImage.Url;
                    }

                }


                UserProfile loggedInUser = new UserProfile(userName, userImageUrl);



                Intent intent = new Intent(this, typeof(HomeActivity));

                intent.PutExtra("loggedInUser", JsonConvert.SerializeObject(loggedInUser));

                //intent.PutExtra("UserName", userName);
                //intent.PutExtra("ProfilePicID", userImageUrl);
                this.StartActivity(intent);
                this.OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.SlideOutRight);











                //if (plusUser.HasTagline)
                //{
                //    //mTagline.Text += plusUser.Tagline;
                //}

                //if (plusUser.HasBraggingRights)
                //{
                //    //mBraggingRights.Text += plusUser.HasBraggingRights;
                //}

                //if (plusUser.HasRelationshipStatus)
                //{
                //    switch (plusUser.RelationshipStatus)
                //    {
                //        case 0:
                //            mRelationship.Text += "Single";
                //            break;

                //        case 1:
                //            mRelationship.Text += "In a relationship";
                //            break;

                //        case 2:
                //            mRelationship.Text += "Engaged";
                //            break;

                //        case 3:
                //            mRelationship.Text += "Married";
                //            break;

                //        case 4:
                //            mRelationship.Text += "It's complicated";
                //            break;

                //        case 5:
                //            mRelationship.Text += "In an open relationship";
                //            break;

                //        case 6:
                //            mRelationship.Text += "Widowed";
                //            break;

                //        case 7:
                //            mRelationship.Text += "In a domestic partnership";
                //            break;

                //        case 8:
                //            mRelationship.Text += "In a civil union";
                //            break;

                //        default:
                //            mRelationship.Text += "Unknown";
                //            break;
                //    }
                //}

                //if (plusUser.HasGender)
                //{
                //    switch (plusUser.Gender)
                //    {
                //        case 0:
                //            mGender.Text += "Male";
                //            break;

                //        case 1:
                //            mGender.Text += "Female";
                //            break;

                //        case 2:
                //            mGender.Text += "Other";
                //            break;

                //        default:
                //            mGender.Text += "Unknown";
                //            break;
                //    }
                //}

                mInfoPopulated = true;
            }
        }

        public void OnConnectionSuspended(int cause)
        {
            throw new NotImplementedException();
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            if (!mIntentInProgress)
            {
                //Store the ConnectionResult so that we can use it later when the user clicks 'sign-in;
                mConnectionResult = result;

                if (mSignInClicked)
                {
                    //The user has already clicked 'sign-in' so we attempt to resolve all
                    //errors until the user is signed in, or the cancel
                    ResolveSignInError();
                }
            }
        }
    }
}