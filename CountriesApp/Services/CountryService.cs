using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CountriesApp
{
	public class CountryService : ICountryService
	{
		HttpClient client = null;
		static List<Country> Countries = new List<Country> ();

		public CountryService ()
		{
			client = new HttpClient();	
		}

		public async Task<List<Country>> GetCountries ()
		{
			var countrynames = await client.GetAsync("http://country.io/names.json");
			var countryCurrencyCodes = await client.GetAsync ("http://country.io/currency.json");
			var countryPhoneCodes = await client.GetAsync ("http://country.io/phone.json");

			var responsecountrynamesdata = await countrynames.Content.ReadAsStringAsync();
			var responsecountryCurrencyCodesdata = await countryCurrencyCodes.Content.ReadAsStringAsync();
			var responsccountryPhoneCodesdata = await countryPhoneCodes.Content.ReadAsStringAsync();

			var resultData = JsonConvert.DeserializeObject<Dictionary<string,string>>(responsecountrynamesdata);
			var resultPhone = JsonConvert.DeserializeObject<Dictionary<string,string>>(responsccountryPhoneCodesdata);
			var resultCurrency = JsonConvert.DeserializeObject<Dictionary<string,string>>(responsecountryCurrencyCodesdata);

			foreach (KeyValuePair<string,string> item in resultData) {
				Countries.Add (new Country { CountryCode = item.Key, CountryName = item.Value });
			}

			if (Countries.Count > 0) {
				foreach (KeyValuePair<string,string> item in resultPhone) {
					Countries.Find (i => i.CountryCode == item.Key).PhoneCode = item.Value;
				}

				foreach (KeyValuePair<string,string> item in resultCurrency) {
					Countries.Find (i => i.CountryCode == item.Key).Currency = item.Value;
				}
			}
			return Countries;
		}
		 
	}
}

