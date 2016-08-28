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
    public class ContactActivity : Activity
    {

        private ListView _contactListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ContactLayout);

            _contactListView = FindViewById<ListView>(Resource.Id.ContactListView);

            List<Contact> contacts = new List<Contact>();

            contacts = JsonConvert.DeserializeObject<List<Contact>>(Intent.GetStringExtra("AllContacts"));

            ContactAdapter contactAdapter = new ContactAdapter(this, contacts);

            _contactListView.Adapter = contactAdapter;
        }
    }
}