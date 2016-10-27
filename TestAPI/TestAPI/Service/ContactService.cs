using AuradiesShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI
{
    public class ContactService
    {
        public List<Contact> GetAllActiveContacts()
        {
            List<Contact> contacts = new List<Contact>();
            DBRepository dbconn = new DBRepository();

            contacts = dbconn.GetAllActiveContacts();

            return (contacts == null) ? new List<Contact>() : contacts;
        }
        public void UpdateContactInactiveById(int contactID)
        {
            List<Contact> contacts = new List<Contact>();
            DBRepository dbconn = new DBRepository();

            dbconn.UpdateContactInactiveById(contactID);
        }
    }
}