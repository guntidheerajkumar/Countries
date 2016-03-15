using System;

using Foundation;
using UIKit;

namespace CountriesApp
{
	public partial class CountryTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("CountryTableViewCell");
		public static readonly UINib Nib;

		static CountryTableViewCell ()
		{
			Nib = UINib.FromName ("CountryTableViewCell", NSBundle.MainBundle);
		}

		public CountryTableViewCell (IntPtr handle) : base (handle)
		{
		}

		public static CountryTableViewCell Create()
		{
			return (CountryTableViewCell)Nib.Instantiate(null,null)[0];
		}
	}
}
