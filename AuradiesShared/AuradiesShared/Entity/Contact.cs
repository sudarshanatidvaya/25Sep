namespace AuradiesShared
{
    public class Contact
    {
        int _id;
        string _contactName;
        string _designation;
        string _contactNumber;
        string _emailID;
        string _category;
        string _officeAddress;
        string _imageID;
        bool _isActive;

        public Contact() { }

        public Contact(int id, string contactName, string designation, string contactNumber, string emailID, string category, string officeAddress, string imageID, bool isActive)
        {
            _id = id;
            _contactName = contactName;
            _designation = designation;
            _contactNumber = contactNumber;
            _emailID = emailID;
            _category = category;
            _officeAddress = officeAddress;
            _imageID = imageID;
            _isActive = isActive;
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
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

        public string OfficeAddress
        {
            get { return _officeAddress; }
            set { _officeAddress = value; }
        }

        public string ImageID
        {
            get { return _imageID; }
            set { _imageID = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }
}