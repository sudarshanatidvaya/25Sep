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

namespace Auradies
{
    public class NewsFeedAdapter : BaseAdapter<NewsFeed>
    {
        private List<NewsFeed> _newsFeeds;
        private Context _context;

        public NewsFeedAdapter(Context context, List<NewsFeed> newsFeeds)
        {
            _newsFeeds = newsFeeds;
            _context = context;
        }
        public override NewsFeed this[int position]
        {
            get
            {
                return _newsFeeds[position];
            }
        }

        public override int Count
        {
            get
            {
                return _newsFeeds.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row==null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.ListRow, null, false);
            }

            TextView user = row.FindViewById<TextView>(Resource.Id.textViewUserProfileName);
            TextView timeStamp = row.FindViewById<TextView>(Resource.Id.textViewUserTimeStamp);
            TextView statusMessage= row.FindViewById<TextView>(Resource.Id.textViewUserPostStatus);
            TextView linkMessage = row.FindViewById<TextView>(Resource.Id.textViewUserPostLink);
            ImageView userImage = row.FindViewById<ImageView>(Resource.Id.imageViewFeedUser);
            ImageView userPostImage = row.FindViewById<ImageView>(Resource.Id.imageViewUserPostImage);


            user.Text = _newsFeeds[position].UserProfileName;
            timeStamp.Text = _newsFeeds[position].TimeStamp;
            statusMessage.Text = _newsFeeds[position].StatusMessage;
            linkMessage.Text = _newsFeeds[position].LinkText;
            Picasso.With(_context).Load(_newsFeeds[position].UserProfilePicID).Into(userImage);
            Picasso.With(_context).Load(_newsFeeds[position].NewsImage).Into(userPostImage);

            //SRMTODO - Images need to be figured out how to assign values to ImageView form URL

            return row;

        }
    }
}