using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PrimeiroApp
{
    public partial class FilmeListaDescricao : UIViewController
    {
        public List<FilmeListaAdd> FilmeListas { get; set; }
        public int row { get; set; }

        public FilmeListaDescricao (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            LabelTituloDesc.Text = FilmeListas[row].Titulo;
            ImageViewDesc.Image = FilmeListas[row].Icone;
            TextViewdesc.Text = FilmeListas[row].Sinopse;


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