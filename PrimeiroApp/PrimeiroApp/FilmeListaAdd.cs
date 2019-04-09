using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PrimeiroApp
{


    public partial class FilmeListaAdd : UIViewController
    {
        public List<string> Filmes { get; set; }
        public List<string> Sinopses { get; set; }

        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public UIImage Icone { get; set; }

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

        partial void ButtonCadastrarFilme_TouchUpInside(UIButton sender)
        {
            var alerta = UIAlertController.Create("Cadastrar Filme", "Tem certeza que deseja cadastrar o filme? ", UIAlertControllerStyle.ActionSheet);
            alerta.AddAction(UIAlertAction.Create("Confirmar", UIAlertActionStyle.Default, HandleAction));
            alerta.AddAction(UIAlertAction.Create("Cancelar", UIAlertActionStyle.Destructive, null));
            PresentViewController(alerta, true, null);

        }

        void HandleAction(UIAlertAction obj)
        {
            filmeLista.Add(new FilmeListaAdd() { Titulo = TextFieldNome.Text, Sinopse = TextFieldSinopse.Text });
        }

        public override void ViewDidLoad()
        {

            filmeLista = new List<FilmeListaAdd>()
            {
                new FilmeListaAdd()
                {
                    Titulo = "Homem-Formiga",
                    Sinopse = "era uma vez uma formiga que virou gente e fim!",
                    Icone = UIImage.FromBundle("Filmes/filme1.png")
                },
                new FilmeListaAdd()
                {
                    Titulo = "Mulher-vespa",
                    Sinopse = "era uma vez uma vespa que virou gente e fim!",
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