using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using static System.Console;


class Program
{

	private static CosmosDBDataAccess db;

	private static async Task Main(string[] args)
	{

		var c = GetCosmosInfo();

		db = new CosmosDBDataAccess(c.endpointUrl, c.primaryKey, c.databaseName, c.containerName);


		ContactModel user = new ContactModel
		{
			FirstName = "Rost",
			LastName = "Kush"
		};

		user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "rost@gmail.com" });
		user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "zholudiev@gmail.com" });
		user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "515 777 532" });
		user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "066 285 02 88" });


		ContactModel user2 = new ContactModel
		{
			FirstName = "Liza",
			LastName = "Kush"
		};

		user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "liza@gmail.com" });
		user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "zholudiev@gmail.com" });
		user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "515 777 532" });
		user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "095 356 89 91" });

		//await CreateContact(user);
		//await CreateContact(user2);

		//await GetAllContacts();


		//bd071838-8558-4e33-a8a9-ff6434bedd98
		//await GetContactById("bd071838-8558-4e33-a8a9-ff6434bedd98");


		//await UpdateContactsFirstName("Zenon", "bd071838-8558-4e33-a8a9-ff6434bedd98");
		//await GetContactById("bd071838-8558-4e33-a8a9-ff6434bedd98");


		//await RemovePhoneNumberFromUser("515 777 532", "bd071838-8558-4e33-a8a9-ff6434bedd98");


		//await RemoveUser("bd071838-8558-4e33-a8a9-ff6434bedd98", "Kush");

		await GetAllContacts();


		WriteLine("Done Processing CosmosDB");
		ReadLine();
	}


	private static async Task RemoveUser(string id, string lastName)
	{
		await db.DeleteRecordAsync<ContactModel>(id, lastName);
	}

	private static async Task RemovePhoneNumberFromUser(string phoneNumber, string id)
	{
		var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

		contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

		await db.UpsertRecordAsync(contact);

	}

	private static async Task UpdateContactsFirstName(string firstName, string id)
	{
		var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

		contact.FirstName = firstName;

		await db.UpsertRecordAsync(contact);

	}

	private static async Task GetContactById(string id)
	{
		var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

		WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
	}

	private static async Task GetAllContacts()
	{
		var contacts = await db.LoadRecordsAsync<ContactModel>();

		foreach (var contact in contacts)
		{
			WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
		}
	}

	private static async Task CreateContact(ContactModel contact)
	{
		await db.UpsertRecordAsync(contact);
	}

	private static (string endpointUrl, string primaryKey, string databaseName, string containerName) GetCosmosInfo()
	{

		(string endpointUrl, string primaryKey, string databaseName, string containerName) output;

		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");

		var config = builder.Build();

		output.endpointUrl = config.GetValue<string>("CosmosDB:EndpointUrl");
		output.primaryKey = config.GetValue<string>("CosmosDB:PrimaryKey");
		output.databaseName = config.GetValue<string>("CosmosDB:DatabaseName");
		output.containerName = config.GetValue<string>("CosmosDB:ContainerName");


		return output;

	}



}