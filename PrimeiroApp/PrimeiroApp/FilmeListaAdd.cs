using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Runtime.CompilerServices;
using CoreGraphics;

namespace PrimeiroApp
{


    public partial class FilmeListaAdd : UIViewController
    {
        public List<string> Filmes { get; set; }
        public List<string> Sinopses { get; set; }

        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public UIImage Icone { get; set; }

        public UIImagePickerController imagePicker { get; set; }
        public UIImageView imagelogo { get; set; }

        public FilmeListaAdd(string titulo, string sinopse, UIImage icone)
        {
            Titulo = titulo;
            Sinopse = sinopse;
            Icone = icone;
        }
        public FilmeListaAdd()
        {

        }

        public List<FilmeListaAdd> filmeLista { get; set; }

        public FilmeListaAdd(IntPtr handle) : base(handle)
        {
            Filmes = new List<string>();
            Sinopses = new List<string>();
        }

        partial void ButtonLoadImage_TouchUpInside(UIButton sender)
        {
            imagelogo = new UIImageView();
            //var permissions = new Permission[] { Permission.Camera, Permission.MediaLibrary };

            //await CrossPermissions.Current.RequestPermissionsAsync(permissions);

            //var Status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.MediaLibrary);

            //if (Status == PermissionStatus.Granted)
            //{
            //await CrossMedia.Current.Initialize();

            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    var alert = UIAlertController.Create("Nao suportado!", "Seu dispositivo nao tem suporte para fotos", UIAlertControllerStyle.Alert);
            //    PresentViewController(alert, true, null);

            //    var selectedImageFile = await CrossMedia.Current.PickPhotoAsync();

            //    if (selectedImageFile == null)
            //    {
            //        var alerta = UIAlertController.Create("ERROR!", "Selecione uma imagem e tente novamente! ", UIAlertControllerStyle.Alert);
            //        PresentViewController(alerta, true, null);
            //    }
            //    var imageData = NSData.FromStream(selectedImageFile.GetStream());
            //    var image = UIImage.LoadFromData(imageData);

            //    Icone = image;

            //}w


                    imagePicker = new UIImagePickerController();

                    // set our source to the photo library
                    imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

                    // set what media types
                    imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

                    imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
                    imagePicker.Canceled += Handle_Canceled;

                    // show the picker
                    NavigationController.PresentModalViewController(imagePicker, true);
                    //UIPopoverController picc = new UIPopoverController(imagePicker);
        }

        // Do something when the
        void Handle_Canceled(object sender, EventArgs e)
        {
            imagePicker.DismissModalViewController(true);
        }

        // This is a sample method that handles the FinishedPickingMediaEvent
        protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
                // get the original image
                UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                    // do something with the image
                   
                    //UIImage logoImage = originalImage;
                    imagelogo.Image = originalImage;
            
            // dismiss the picker
            imagePicker.DismissModalViewController(true);
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
            filmeLista.Add(new FilmeListaAdd() { Titulo = TextFieldNome.Text, Sinopse = TextFieldSinopse.Text, Icone = imagelogo.Image });
        }

        public override void ViewDidLoad()
        {

            filmeLista = new List<FilmeListaAdd>()
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
                var testeclasse = segue.DestinationViewController as FilmeLista;
                testeclasse.filmeListas = filmeLista;
            }
        }
    }
}