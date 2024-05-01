using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using static System.Console;


class Program
{

	private static MongoDBDataAccess db;
	private static readonly string tableName = "Contacts";

	static void Main(string[] args)
	{

		db = new MongoDBDataAccess("MongoContactsDB", GetConnectionString());


		ContactModel user = new ContactModel
		{
			FirstName = "Liza",
			LastName = "Kush"
		};

		user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "liza@gmail.com" });
		user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "zholudiev@gmail.com" });
		user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "515 777 532" });
		user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "066 285 02 88" });

		//CreateContact(user);

		GetAllContacts();

		//GetContactById("b2ec33d2-c3f0-4797-99fd-eb8c5c9cfe40");

		//UpdateContactsFirstName("Rostyslav", "1762a6fd-7dc3-4447-8c57-f86b9f189f6d");
		//GetAllContacts();

		//RemovePhoneNumberFromUser("066 285 02 88", "1762a6fd-7dc3-4447-8c57-f86b9f189f6d");

		//RemoveUser("1762a6fd-7dc3-4447-8c57-f86b9f189f6d");


		WriteLine("Done Processing MongoDB");
		ReadLine();


	}

	private static void RemoveUser(string id)
	{
		Guid guid = new Guid(id);
		db.DeleteRecord<ContactModel>(tableName, guid);
	}

	private static void RemovePhoneNumberFromUser(string phoneNumber, string id)
	{
		Guid guid = new Guid(id);
		var contact = db.LoadRecordById<ContactModel>(tableName, guid);

		contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

		db.UpsertRecord(tableName, contact.Id, contact);
	}

	private static void UpdateContactsFirstName(string firstName, string id)
	{
		Guid guid = new Guid(id);
		var contact = db.LoadRecordById<ContactModel>(tableName, guid);

		contact.FirstName = firstName;

		db.UpsertRecord(tableName, contact.Id, contact);
	}

	private static void GetContactById(string id)
	{
		Guid guid = new Guid(id);

		var contact = db.LoadRecordById<ContactModel>(tableName, guid);
		WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");


	}

	private static void GetAllContacts()
	{
		var contacts = db.LoadRecords<ContactModel>(tableName);

		foreach (var contact in contacts)
		{
			WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
		}
	}

	private static void CreateContact(ContactModel contact)
	{
		db.UpsertRecord(tableName, contact.Id, contact);
	}

	private static string GetConnectionString(string connectionStringName = "Default")
	{

		string output = "";

		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");

		var config = builder.Build();

		output = config.GetConnectionString(connectionStringName);

		return output;

	}






}