using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountriesApp
{
	public interface ICountryService
	{
		Task<List<Country>> GetCountries();
	}
}

