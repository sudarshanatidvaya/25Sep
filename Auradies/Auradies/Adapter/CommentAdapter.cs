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
    public class CommentAdapter : BaseAdapter<NewsFeedComment>
    {
        private List<NewsFeedComment> _newsFeedComments;
        private Context _context;

        public CommentAdapter(Context context, List<NewsFeedComment> newsFeedComments)
        {
            _newsFeedComments = newsFeedComments;
            _context = context;
        }
        public override NewsFeedComment this[int position]
        {
            get
            {
                return _newsFeedComments[position];
            }
        }

        public override int Count
        {
            get
            {
                return _newsFeedComments.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.CommentsRow, null, false);
            }

            TextView commentUser = row.FindViewById<TextView>(Resource.Id.textViewContactName);
            TextView comment = row.FindViewById<TextView>(Resource.Id.textViewComment);


            commentUser.Text = string.Format("{0}: ", _newsFeedComments[position].UserName);
            comment.Text = _newsFeedComments[position].Comment;

            //SRMTODO - Images need to be figured out how to assign values to ImageView form URL

            return row;
        }
    }
}