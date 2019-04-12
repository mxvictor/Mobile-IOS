using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using SQLite;
using UIKit;

namespace PrimeiroApp
{

    [Table("Filmes")]
    public class Filme
    {
        [PrimaryKey,AutoIncrement,Column("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Titulo { get; set; }

        public byte[] Icone { get; set; }

        [MaxLength(1000)]
        public string Sinopse { get; set; }
    }

    public class DataAccess
    {
        public void  ConnectData()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "filmes.db3");

            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Filme>();

            if (db.Table<Filme>().Count() == 0)
            {
                var newFilme = new Filme();
                var FilmeListas= new List<FilmeListaAdd>()
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
                db.InsertAll(FilmeListas);
            }
        }

        public List<FilmeListaAdd> FilmesLista()
        {
             List<FilmeListaAdd> filme = new List<FilmeListaAdd>();
            FilmeListaAdd filme1 = new FilmeListaAdd();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "filmes.db3");

            var db = new SQLiteConnection(dbPath);
            var query = db.Query<Filme>("SELECT * FROM [Filmes]");

            foreach (var s in query)
            {
                filme1.Titulo = s.Titulo;
                filme1.Sinopse = s.Sinopse;
                filme.Add(filme1);
            }
            return filme;
        }
    }


}
