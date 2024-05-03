using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace DataAccessLibrary.Models
{
	public class ContactModel
	{
		[BsonId]
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<EmailAddressModel> EmailAddresses { get; set; } = new();
		public List<PhoneNumberModel> PhoneNumbers { get; set; } = new();
	}
}
