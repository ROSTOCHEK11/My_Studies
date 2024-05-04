using LinqUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUI
{
	public static class SampleData
	{
		public static List<ContactModel> GetContactData()
		{

			List<ContactModel> output = new List<ContactModel>
			{
				new ContactModel{ Id = 1, FirstName = "Rost", LastName = "Zhol", Addresses = new List<int> { 1, 2, 3,}},
				new ContactModel{ Id = 2, FirstName = "Ivan", LastName = "Petrov", Addresses = new List<int> { 1 }},
				new ContactModel{ Id = 3, FirstName = "Damian", LastName = "Nowak", Addresses = new List<int> { 2 }},
				new ContactModel{ Id = 4, FirstName = "James", LastName = "Smith", Addresses = new List<int> { 3 }},
				new ContactModel{ Id = 5, FirstName = "Liza", LastName = "Kush", Addresses = new List<int> { 2, 3,}}
			};
			return output;

		}



		public static List<AddressModel> GetAddressData()
		{
			List<AddressModel> output = new List<AddressModel>
			{
				new AddressModel{ Id = 1, ContactId = 1, City = "Kyiv", Region = "Kyiv region"},
				new AddressModel{ Id = 2, ContactId = 1, City = "Warsaw", Region = "Mazowieckie"},
				new AddressModel{ Id = 3, ContactId = 2, City = "Miami", Region = "Florida"},
				new AddressModel{ Id = 4, ContactId = 5, City = "Warsaw", Region = "Mazowieckie"},
				new AddressModel{ Id = 5, ContactId = 5, City = "Miami", Region = "Florida"},
				new AddressModel{ Id = 6, ContactId = 4, City = "Kyiv", Region = "Kyiv region"},
				new AddressModel{ Id = 7, ContactId = 3, City = "Warsaw", Region = "Mazowieckie"},

			};
			return output;
		}





	}
}
