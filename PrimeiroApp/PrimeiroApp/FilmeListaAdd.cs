using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Runtime.CompilerServices;
using CoreGraphics;
using SQLite;
using SQLitePCL;

namespace PrimeiroApp
{


    public partial class FilmeListaAdd : UIViewController
    {

        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public UIImage Icone { get; set; }

        public UIImagePickerController ImagePicker { get; set; }
        public UIImageView Imagelogo { get; set; }

        DataAccess db = new DataAccess();

        public FilmeListaAdd(string titulo, string sinopse, UIImage icone)
        {
            Titulo = titulo;
            Sinopse = sinopse;
            Icone = icone;
        }
        public List<Filme> FilmeListas_ { get; set; }

        public FilmeListaAdd()
        {

        }

        public FilmeListaAdd(IntPtr handle) : base(handle)
        {

        }

        partial void ButtonLoadImage_TouchUpInside(UIButton sender)
        {
            Imagelogo = new UIImageView();

            ImagePicker = new UIImagePickerController();

            // set our source to the photo library
            ImagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

            // set what media types
            ImagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

            ImagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            ImagePicker.Canceled += Handle_Canceled;

            // show the picker
            NavigationController.PresentModalViewController(ImagePicker, true);
            //UIPopoverController picc = new UIPopoverController(imagePicker);
        }
        // Do something when the
        void Handle_Canceled(object sender, EventArgs e)
        {
            ImagePicker.DismissModalViewController(true);
        }

        // This is a sample method that handles the FinishedPickingMediaEvent
        protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            // get the original image
            UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
            // do something with the image

            //UIImage logoImage = originalImage;
            Imagelogo.Image = originalImage;

            // dismiss the picker
            ImagePicker.DismissModalViewController(true);
        }


        partial void ButtonCadastrarFilme_TouchUpInside(UIButton sender)
        {
            var alerta = UIAlertController.Create("Cadastrar Filme", "Tem certeza que deseja cadastrar o filme? ", UIAlertControllerStyle.ActionSheet);
            alerta.AddAction(UIAlertAction.Create("Confirmar", UIAlertActionStyle.Default, HandleAction));
            alerta.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Destructive, null));
            PresentViewController(alerta, true, null);

        }

        void HandleAction(UIAlertAction obj)
        {
            FilmeListas_ = new List<Filme>();

            FilmeListas_.Add(new Filme() { Titulo = TextFieldNome.Text, Sinopse = TextFieldSinopse.Text, Icone = ImageToByteArray(Imagelogo.Image) });
            db.Cadastrar(FilmeListas_);
        }


        public static byte[] ImageToByteArray(UIImage _image)
        {
            Byte[] byteArray;
            using (NSData nsImageData = _image.AsPNG())
            {
                byteArray = new Byte[nsImageData.Length];
                System.Runtime.InteropServices.Marshal.Copy(nsImageData.Bytes, byteArray, 0, Convert.ToInt32(nsImageData.Length));
            }

            return byteArray;
        }
        public override void ViewDidLoad()
        {

            var textView = new UITextView();
            textView.Layer.CornerRadius = 5;
            textView.Layer.BorderColor = UIColor.Black.CGColor;
            textView.Layer.BorderWidth = 1;


            db.ConnectData();
            List<Filme> FilmeListar = db.FilmesLista();
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            View.EndEditing(true);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);

        //    if (segue.Identifier == "ListarFilmesSegue")
        //    {
        //        var segueFilmeLista = segue.DestinationViewController as FilmeLista;
        //        segueFilmeLista.FilmeListas = FilmeListas;
        //    }
        //}
    }
}