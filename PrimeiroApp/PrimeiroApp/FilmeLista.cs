using Foundation;
using System;
using UIKit;
using System.Collections.Generic;


namespace PrimeiroApp
{
    public partial class FilmeLista : UITableViewController
    {
        static NSString filmeCellId = new NSString("FilmeCell");

        public List<FilmeListaAdd> filmeListas { get; set; }

        public void MostrarAlerta(UIAlertController alerta)
        {
            PresentViewController(alerta, true, null);
        }


        public FilmeLista(IntPtr handle) : base(handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), filmeCellId);
            TableView.Source = new FilmeListaDataSource(this);
        }

        class FilmeListaDataSource : UITableViewSource
        {
            FilmeLista controller;

            public FilmeListaDataSource(FilmeLista controller)
            {
                this.controller = controller;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return controller.filmeListas.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                FilmeListaAdd filme = new FilmeListaAdd();
                var cell = tableView.DequeueReusableCell(FilmeLista.filmeCellId);
                int row = indexPath.Row;
                cell.TextLabel.Text = controller.filmeListas[row].Titulo;
                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                tableView.DeselectRow(indexPath, true);

                int row = indexPath.Row;
                var alerta = UIAlertController.Create("Sinopse", controller.filmeListas[row].Sinopse, UIAlertControllerStyle.Alert);
                alerta.AddAction(UIAlertAction.Create("Voltar", UIAlertActionStyle.Default, null));
                controller.MostrarAlerta(alerta);

            }
        }
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
    }
}