using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Biz
{
	public enum CustomerType
	{
		Vip, Normal, Personal, Business
	}
	public class Customer
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public CustomerType CustomerType { get; set; }
	}
	public class CustomerSerivce
	{
		private readonly List<Customer> _customers = new List<Customer>()
		{
			new Customer()
			{
				AccountNumber = "1",
				Balance = 1000000000000,
				CustomerName = "X",
				CustomerType = CustomerType.Vip,
				Id = 1
			},
			new Customer()
			{
				AccountNumber = "2",
				Balance = 1000000000000,
				CustomerName = "Y",
				CustomerType = CustomerType.Personal,
				Id = 2
			},
			new Customer()
			{
				AccountNumber = "3",
				Balance = 1000000000000,
				CustomerName = "Z",
				CustomerType = CustomerType.Normal,
				Id = 3
			},
			new Customer()
			{
				AccountNumber = "4",
				Balance = 1000000000000,
				CustomerName = "J",
				CustomerType = CustomerType.Business,
				Id = 4
			}
		};
		public Customer Get(string customerName, string accountNumber)
		{
			if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(accountNumber))
			{
				return null;
			}
			return _customers.FirstOrDefault(s => s.CustomerName.ToLower() == customerName.ToLower() &&
												s.AccountNumber.ToLower() == accountNumber.ToLower());
		}
	}
}