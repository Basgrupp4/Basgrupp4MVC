using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Basgrupp4MVC.Models;

namespace Basgrupp4MVC.Data.Models

{
    public class ContactManager
    {
        private ApplicationDbContext _context;
        public ContactManager()
        {
            _context = new ApplicationDbContext();
        }

        public ContactModels GetContact(int id)
        {
            var contact = _context.ContactModels.Single(x => x.ID == id); 
            var model = new ContactModels
            {
                ID = contact.ID,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Age = contact.Age,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber

            };

            return model;
        }

        public void CreateContact(ContactModels model)
        {
        }

        public List<ContactModels> GetAllContacts()
        {
            var models = _context.ContactModels.Select(contact => new ContactModels
            {
                ID = contact.ID,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Age = contact.Age,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber
            }).ToList();

            return models;

        }
    }
}