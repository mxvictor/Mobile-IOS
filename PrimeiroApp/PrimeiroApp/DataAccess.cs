using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using SQLite;
using UIKit;
using static System.Net.Mime.MediaTypeNames;

namespace PrimeiroApp
{

    [Table("Filmes")]
    public class Filme
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Titulo { get; set; }

       // public string Icone { get; set; }

        [MaxLength(1000)]
        public string Sinopse { get; set; }
    }

    public class DataAccess
    {
        public SQLiteConnection db;

        public List<Filme> FilmesListas { get; set; }

        public DataAccess()
        {
            db = null;
        }

        public void ConnectData()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "filmesLista.db3");
           

            db = new SQLiteConnection(dbPath);

            //db.CreateTable<Filme>();

            //    if (db.Table<Filme>().Count() == 0)
            //    {
            //    //var img = UIImage.FromBundle("Filmes/filme1.png");
            //    //NSData image = img.AsPNG();
            //    //NSError err = null;
            //    //image.Save()


            //    FilmesListas = new List<Filme>()

            //       // var newFilme = new Filme();
            //       // newFilme.Titulo = "estou testando isso";
            //       //db.Insert(newFilme);

            //{
            //    new Filme()
            //    {
            //        Titulo = "007 - Quantum of Solace",
            //        Sinopse = "Após a morte de Vesper Lynd, James Bond faz com que sua próxima missão seja pessoal. " +
            //            "A caçada àqueles envolvidos na morte da mulher de sua vida o leva ao encontro do cruel empresário Dominic Greene, que" +
            //            " faz parte da organização que coagiu Vesper. Bond descobre que Greene planeja obter o controle total de um recurso natural " +
            //            "vital e deve enfrentar perigo e traição para frustrar o plano.",
            //         Convert.ToString(UIImage.FromBundle("Filmes/filme1.png"))

            //    },
            //    new Filme()
            //    {
            //        Titulo = "Star Wars: O Despertar da Força",
            //        Sinopse = "A queda de Darth Vader e do Império levou ao surgimento de uma nova força sombria: a Primeira Ordem." +
            //            " Eles procuram o jedi Luke Skywalker, desaparecido. A resistência tenta desesperadamente " +
            //            "encontrá-lo antes para salvar a galáxia.",
            //         Icone = Convert.ToString(UIImage.FromBundle("Filmes/filme2.png"))
            //    }

            //};
            //    db.InsertAll(FilmesListas);
            //}

        }

        public void Cadastrar(List<Filme> FilmeListas)
        {
            db.InsertAll(FilmeListas);
        }

        public List<Filme> FilmesLista()
        {
            List<FilmeListaAdd> filme = new List<FilmeListaAdd>();
            FilmeListaAdd filme1 = new FilmeListaAdd();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "filmesLista.db3");
            if (db == null)
            {
                db = new SQLiteConnection(dbPath);
            }

            return db.Query<Filme>("SELECT * FROM [Filmes]")as List<Filme>;
            }
        }
    }
