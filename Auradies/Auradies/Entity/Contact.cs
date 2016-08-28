namespace Auradies
{
    public class Contact
    {
        string _contactName;
        string _designation;
        string _contactNumber;
        string _emailID;
        string _category;

        public Contact() { }

        public Contact(string contactName, string designation, string contactNumber, string emailID, string category)
        {
            _contactName = contactName;
            _designation = designation;
            _contactNumber = contactNumber;
            _emailID = emailID;
            _category = category;
        }

        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
    }
}