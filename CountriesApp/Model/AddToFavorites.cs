using System;
using SQLite;

namespace CountriesApp
{
	public class AddToFavorites
	{
		[PrimaryKey]
		public string CountryCode {
			get;
			set;
		}

		public string CountryName {
			get;
			set;
		}

		public string PhoneCode {
			get;
			set;
		}

		public string Currency {
			get;
			set;
		}
	}
}

