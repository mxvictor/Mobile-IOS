using Foundation;
using System;
using UIKit;

namespace PrimeiroApp
{
    public partial class PrimeiraTableView : UITableViewController
    {
        public PrimeiraTableView (IntPtr handle) : base (handle)
        {
        }

        static NSString filmeCellId = new NSString("FilmeCell");
        public string[] filme = new string[5];

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        [Export("numberOfSectionsInTableView:")]
        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return base.RowsInSection(tableView, section);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            filme[0] = "Vingadores Ultimato";
            filme[1] = "Vingadores Guerra Infinita";
            filme[2] = "Vingadores Guerra Civil";

            var cell = tableView.DequeueReusableCell(PrimeiraTableView.filmeCellId);
           // int row = indexPath.Row;
            cell.TextLabel.Text = filme[indexPath.Row];

            return cell;

        }
    }
}