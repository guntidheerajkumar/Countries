// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CountriesApp
{
	[Register ("CountryTableViewCell")]
	partial class CountryTableViewCell
	{
		[Outlet]
		public UIKit.UILabel CountryCurrency { get; set; }

		[Outlet]
		public UIKit.UIImageView CountryImage { get; set; }

		[Outlet]
		public UIKit.UILabel CountryName { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CountryCurrency != null) {
				CountryCurrency.Dispose ();
				CountryCurrency = null;
			}
			if (CountryImage != null) {
				CountryImage.Dispose ();
				CountryImage = null;
			}
			if (CountryName != null) {
				CountryName.Dispose ();
				CountryName = null;
			}
		}
	}
}
