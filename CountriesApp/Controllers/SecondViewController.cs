using System;

using UIKit;
using System.Collections.Generic;
using Foundation;

namespace CountriesApp
{
	public partial class SecondViewController : UIViewController
	{
		DBLayer layer = new DBLayer();
		public SecondViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();	
			this.Title = "Favorites";
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			var favoritesData = layer.GetAllFavorites ();
			if (favoritesData.Count > 0) {
				NoFavoritesMessage.Hidden = true;
				var tableSource = new AddToFavoritesTableSource (favoritesData); 
				tableSource.NoAddToFavorites = NoFavoritesMessage;
				AddToFavoritesTableView.Source = tableSource;
				AddToFavoritesTableView.Hidden = false;
			} else {
				NoFavoritesMessage.Hidden = false;
				AddToFavoritesTableView.Hidden = true;
			}
		}

	}

	public class AddToFavoritesTableSource : UITableViewSource {

		private List<AddToFavorites> TableItems; 
		public UILabel NoAddToFavorites;
		private DBLayer layer = new DBLayer();

		public AddToFavoritesTableSource (List<AddToFavorites> items)
		{
			TableItems = items;
		}

		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
		{
			switch (editingStyle) {
			case UITableViewCellEditingStyle.Delete:
				layer.DeleteAsFavorite (TableItems [indexPath.Row]);
				TableItems.RemoveAt (indexPath.Row);
				tableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				if (TableItems.Count == 0) {
					NoAddToFavorites.Hidden = false;
					tableView.Hidden = true;
				}
				break;
			}
		}
		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true; 
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			AddToFavorites item = TableItems[indexPath.Row];
			var cell = CountryTableViewCell.Create();
			cell.CountryName.Text = item.CountryCode + " - " + item.CountryName;
			cell.CountryImage.Image = UIImage.FromBundle ("Countries/" + item.CountryCode);
			cell.CountryCurrency.Text = item.Currency;
			return cell;
		} 
	}
}

