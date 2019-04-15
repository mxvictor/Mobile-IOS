using Foundation;
using System;
using UIKit;
using System.Collections.Generic;


namespace PrimeiroApp
{
    public partial class FilmeLista : UITableViewController
    {
        static NSString filmeCellId = new NSString("FilmeCell");

        public List<Filme> FilmeListas { get; set; }
        public int row1 { set; get; }
        DataAccess db = new DataAccess();

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

                List<Filme> FilmeListar = controller.db.FilmesLista();
                return FilmeListar.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                List<Filme> FilmeListar = controller.db.FilmesLista();

                UIImage img = new UIImage();

                var cell = tableView.DequeueReusableCell(FilmeLista.filmeCellId);
                int row = indexPath.Row;
                cell.TextLabel.Text = FilmeListar[row].Titulo;
                //cell.ImageView.Image = FilmeListar[row].Icone);
                cell.ImageView.Layer.CornerRadius = 50;
                cell.ImageView.ClipsToBounds = true;

                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
            
                controller.row1 = indexPath.Row;
                tableView.DeselectRow(indexPath, true);

                controller.PerformSegue("DescricaoSegue", controller);
               
                //    //var alerta = UIAlertController.Create("Sinopse", controller.filmeListas[row].Sinopse, UIAlertControllerStyle.Alert);
                //    //alerta.AddAction(UIAlertAction.Create("Voltar", UIAlertActionStyle.Default, null));
                //    //controller.MostrarAlerta(alerta);

            }

        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {

            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "DescricaoSegue")
            {
                FilmeListas = db.FilmesLista();
                var segueDescricao = segue.DestinationViewController as FilmeListaDescricao;
                segueDescricao.FilmeListas = FilmeListas;
                segueDescricao.row = row1;
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