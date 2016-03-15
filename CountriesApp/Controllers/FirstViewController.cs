using System;

using UIKit;
using System.Threading.Tasks;
using System.Collections.Generic;
using Foundation;
using CoreGraphics; 
using System.Threading;

namespace CountriesApp
{
	public partial class FirstViewController : UIViewController
	{
		public FirstViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad (); 
			this.Title = "Countries";
			this.NavigationItem.Title = "Countries";
		}

		public async override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			ICountryService service = new CountryService ();
			List<Country> countryData;
			DBLayer layer = new DBLayer ();
			if (layer.GetCountries ().Count == 0) {
				countryData = await service.GetCountries ();
				layer.InsertData (countryData);
			} else {
				countryData = layer.GetCountries ();
			}
			var tableData = new CountriesTableSource (countryData);
			tableData.NavigationController = this.NavigationController;
			CountriesTableView.Source = tableData;
			CountriesTableView.ReloadData ();
		}
	}

	public class CountriesTableSource : UITableViewSource {

		List<Country> TableItems;
		public UINavigationController NavigationController;

		public CountriesTableSource (List<Country> items)
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

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			Country item = TableItems[indexPath.Row];
			var cell = CountryTableViewCell.Create();
			cell.CountryName.Text = item.CountryCode + " - " + item.CountryName;
			cell.CountryImage.Image = UIImage.FromBundle ("Countries/" + item.CountryCode);
			cell.CountryCurrency.Text = item.Currency;
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (NavigationController != null) {
				var storyBoard = UIStoryboard.FromName("Main", null);
				var detailController = (DetailViewController)storyBoard.InstantiateViewController ("DetailViewController");
				Constants.CountryCode = TableItems [indexPath.Row].CountryCode;
				NavigationController.ShowViewController (detailController, null);
			}
		}
	}
}

