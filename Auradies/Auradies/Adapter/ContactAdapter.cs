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
    class ContactAdapter : BaseAdapter<Contact>
    {
        private List<Contact> _contacts;
        private Context _context;

        public ContactAdapter(Context context, List<Contact> newsFeeds)
        {
            _contacts = newsFeeds;
            _context = context;
        }
        public override Contact this[int position]
        {
            get
            {
                return _contacts[position];
            }
        }

        public override int Count
        {
            get
            {
                return _contacts.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            try
            {

                if (row == null)
                {
                    row = LayoutInflater.From(_context).Inflate(Resource.Layout.ContactRow, null, false);
                }

                TextView contact = row.FindViewById<TextView>(Resource.Id.textViewContactName);
                TextView contactProfile = row.FindViewById<TextView>(Resource.Id.textViewContactProfile);
                TextView phoneNumber = row.FindViewById<TextView>(Resource.Id.textViewContactPhoneNumber);
                TextView category = row.FindViewById<TextView>(Resource.Id.textViewContactCategory);
                TextView mailID = row.FindViewById<TextView>(Resource.Id.textViewContactMailID);


                contact.Text = _contacts[position].ContactName;
                contactProfile.Text = _contacts[position].Designation;
                phoneNumber.Text = _contacts[position].ContactNumber;
                category.Text = _contacts[position].Category;
                mailID.Text = _contacts[position].EmailID;

                return row;
            }

            catch (Exception ex)
            {
                return row;

            }
        }
    }
}