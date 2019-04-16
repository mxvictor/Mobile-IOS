using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PrimeiroApp
{
    public partial class FilmeListaDescricao : UIViewController
    {
        public List<Filme> FilmeListas { get; set; }
        public int row { get; set; }

        public FilmeListaDescricao (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {

            LabelTituloDesc.Text = FilmeListas[row].Titulo;
            ImageViewDesc.Image = ByteArrayToImage(FilmeListas[row].Icone);
            TextViewdesc.Text = FilmeListas[row].Sinopse;


            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public static UIImage ByteArrayToImage(byte[] _imageBuffer)
        {
            if (_imageBuffer != null)
            {
                if (_imageBuffer.Length != 0)
                {
                    NSData imageData = NSData.FromArray(_imageBuffer);
                    return UIImage.LoadFromData(imageData);
                }
                else
                    return new UIImage();

            }
            else
                return new UIImage();
        }

    }
}