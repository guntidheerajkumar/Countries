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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton BtnAddFavorites { get; set; }

		[Outlet]
		UIKit.UILabel CountryCurrency { get; set; }

		[Outlet]
		UIKit.UIImageView CountryImage { get; set; }

		[Outlet]
		UIKit.UILabel CountryName { get; set; }

		[Outlet]
		UIKit.UILabel CountryPhoneCode { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BtnAddFavorites != null) {
				BtnAddFavorites.Dispose ();
				BtnAddFavorites = null;
			}
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
			if (CountryPhoneCode != null) {
				CountryPhoneCode.Dispose ();
				CountryPhoneCode = null;
			}
		}
	}
}
