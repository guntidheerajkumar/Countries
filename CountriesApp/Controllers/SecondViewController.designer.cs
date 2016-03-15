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
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		UIKit.UITableView AddToFavoritesTableView { get; set; }

		[Outlet]
		UIKit.UILabel NoFavoritesMessage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddToFavoritesTableView != null) {
				AddToFavoritesTableView.Dispose ();
				AddToFavoritesTableView = null;
			}
			if (NoFavoritesMessage != null) {
				NoFavoritesMessage.Dispose ();
				NoFavoritesMessage = null;
			}
		}
	}
}
