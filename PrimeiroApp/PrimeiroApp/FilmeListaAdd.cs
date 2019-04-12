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

        public DataAccess db = new DataAccess();

        public FilmeListaAdd(string titulo, string sinopse, UIImage icone)
        {
            Titulo = titulo;
            Sinopse = sinopse;
            Icone = icone;

            //string dbPath = dbPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
            //var db = new SQLiteConnection(dbPath);
        }
        public FilmeListaAdd()
        {

        }

        public List<FilmeListaAdd> FilmeListas { get; set; }

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
            FilmeListas.Add(new FilmeListaAdd() { Titulo = TextFieldNome.Text, Sinopse = TextFieldSinopse.Text, Icone = Imagelogo.Image });
        }

        public override void ViewDidLoad()
        {

            FilmeListas = new List<FilmeListaAdd>()
            {
                new FilmeListaAdd()
                {
                    Titulo = "007 - Quantum of Solace",
                    Sinopse = "Após a morte de Vesper Lynd, James Bond faz com que sua próxima missão seja pessoal. " +
                        "A caçada àqueles envolvidos na morte da mulher de sua vida o leva ao encontro do cruel empresário Dominic Greene, que" +
                        " faz parte da organização que coagiu Vesper. Bond descobre que Greene planeja obter o controle total de um recurso natural " +
                        "vital e deve enfrentar perigo e traição para frustrar o plano.",
                    Icone = UIImage.FromBundle("Filmes/filme1.png")
                },
                new FilmeListaAdd()
                {
                    Titulo = "Star Wars: O Despertar da Força",
                    Sinopse = "A queda de Darth Vader e do Império levou ao surgimento de uma nova força sombria: a Primeira Ordem." +
                        " Eles procuram o jedi Luke Skywalker, desaparecido. A resistência tenta desesperadamente " +
                        "encontrá-lo antes para salvar a galáxia.",
                    Icone = UIImage.FromBundle("Filmes/filme2.png")
                }

            };
            db.ConnectData();
            FilmeListas = db.FilmesLista();
            TextFieldNome.Text = FilmeListas[0].Titulo;
            TextFieldSinopse.Text = FilmeListas[0].Sinopse;
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "ListarFilmesSegue")
            {
                var segueFilmeLista = segue.DestinationViewController as FilmeLista;
                segueFilmeLista.FilmeListas = FilmeListas;
            }
        }
    }
}