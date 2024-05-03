namespace ApiDBUI.Models
{

	public class ContactModel
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<EmailAddressModel> EmailAddresses { get; set; } = new();
		public List<PhoneNumberModel> PhoneNumbers { get; set; } = new();
	}

}
