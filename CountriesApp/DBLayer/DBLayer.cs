using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountriesApp
{
	public class DBLayer
	{
		private string dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal),"database.db3");
		SQLiteAsyncConnection connection;
		public DBLayer ()
		{
			connection = new SQLiteAsyncConnection (dbPath);
		}

		public void CreateDatabase()
		{
				connection.CreateTableAsync<Country> (); 
				connection.CreateTableAsync<AddToFavorites> ();
		}

		public void DeleteTables()
		{
			connection.DropTableAsync<Country> ();
			connection.DropTableAsync<AddToFavorites> ();
		}

		public void InsertData(List<Country> items)
		{
			connection.InsertAllAsync (items);
		}

		public List<Country> GetCountries()
		{
			return connection.QueryAsync<Country> ("select * from country").Result;
		}

		public Country FindCountry(string CountryCode)
		{
			return connection.FindAsync<Country> (p => p.CountryCode == CountryCode).Result;
		}

		public void AddToFavorites(AddToFavorites addToFavorites)
		{
			connection.InsertAsync (addToFavorites);
		}

		public List<AddToFavorites> GetAllFavorites()
		{
			return connection.QueryAsync<AddToFavorites> ("select * from AddToFavorites").Result;
		}

		public AddToFavorites FindFavorite(string CountryCode)
		{
			return connection.FindAsync<AddToFavorites> (p => p.CountryCode == CountryCode).Result;
		}

		public int DeleteAsFavorite(AddToFavorites addToFavorites)
		{
			return connection.DeleteAsync (addToFavorites).Result;
		}
	}
}

