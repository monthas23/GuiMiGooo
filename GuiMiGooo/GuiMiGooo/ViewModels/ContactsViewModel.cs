using GuiMiGooo.Models;
using GuiMiGooo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class ContactsViewModel : BaseViewM
    {
        public ObservableCollection<Contact> UserContacts { get; set; }
        public ContactsViewModel(GuiMiGoommaServices utilServices)
        {
            this.utilServices = utilServices;
            RetrieveContacts = new Command(RetrieveContactsCommandClicked);
        }

        private async void RetrieveContactsCommandClicked(object obj)
        {
            Contact pickedContact = new Contact();

            pickedContact = await Contacts.PickContactAsync();

            ObservableCollection<Contact> contactsCollect = new ObservableCollection<Contact>();
            var cancellationToken = default(CancellationToken);
            var allContacts = await Contacts.GetAllAsync(cancellationToken);

            foreach (var contact in allContacts)
                contactsCollect.Add(contact);

            var id = pickedContact.Id;
            var namePrefix = pickedContact.NamePrefix;
            var givenName = pickedContact.GivenName;
            var middleName = pickedContact.MiddleName;
            var familyName = pickedContact.FamilyName;
            var nameSuffix = pickedContact.NameSuffix;
            var displayName = pickedContact.DisplayName;
            var phones = pickedContact.Phones; // List of phone numbers
            var emails = pickedContact.Emails; // List of email addresses
        }

        public Command RetrieveContacts { get; private set; }

        public async Task Initialize()
        {
            await Initialize("");
        }

        private async Task Initialize(string v = null)
        {
            UserContacts = await utilServices.GetContacts();
        }
    }
}
