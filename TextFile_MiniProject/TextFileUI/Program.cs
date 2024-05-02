using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using static System.Console;



class Program
{

	private static IConfiguration _config;
	private static string textFile;
	private static TextFileDataAccess db = new();

	private static void Main(string[] args)
	{

		InitializeConfiguration();

		textFile = _config.GetValue<string>("TextFile");


		ContactModel user1 = new ContactModel();
		user1.FirstName = "Rost";
		user1.LastName = "Bimbowich";
		user1.EmailAddresses.Add("sdfg@gmail.com");
		user1.EmailAddresses.Add("bimba123@gmail.com");
		user1.PhoneNumbers.Add("939-993-55-09");
		user1.PhoneNumbers.Add("083-2354-22");

		ContactModel user2 = new ContactModel();
		user2.FirstName = "Labrador";
		user2.LastName = "TheDog";
		user2.EmailAddresses.Add("gawgaw@gmail.com");
		user2.EmailAddresses.Add("tastyfood123@gmail.com");
		user2.PhoneNumbers.Add("999-000-25-11");
		user2.PhoneNumbers.Add("454-678-098");


		//CreateContact(user1);
		//CreateContact(user2);

		//GetAllContacts();

		//UpdateFirstContactsFirstName("Rostyslav");
		//GetAllContacts();

		//WriteLine("===");

		//RemovePhoneNumberFromFirstUser("083-2354-22");
		//GetAllContacts();

		//RemoveFirstUser();
		//GetAllContacts();

		WriteLine("Done processing text file");
		ReadLine();

	}


	private static void RemoveFirstUser()
	{
		var contacts = db.ReadAllRecords(textFile);

		contacts.RemoveAt(0);

		db.WriteAllRecords(contacts, textFile);
	}

	private static void RemovePhoneNumberFromFirstUser(string phoneNumber)
	{
		var contacts = db.ReadAllRecords(textFile);

		contacts[0].PhoneNumbers.Remove(phoneNumber);

		db.WriteAllRecords(contacts, textFile);
	}

	private static void UpdateFirstContactsFirstName(string firstName)
	{
		var contacts = db.ReadAllRecords(textFile);

		contacts[0].FirstName = firstName;

		db.WriteAllRecords(contacts, textFile);

	}

	private static void GetAllContacts()
	{
		var contacts = db.ReadAllRecords(textFile);

		foreach (var contact in contacts)
		{
			WriteLine($"{contact.FirstName} {contact.LastName}");
		}
	}

	private static void CreateContact(ContactModel contact)
	{
		var contacts = db.ReadAllRecords(textFile);

		contacts.Add(contact);

		db.WriteAllRecords(contacts, textFile);


	}


	private static void InitializeConfiguration()
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");

		_config = builder.Build();

	}


}