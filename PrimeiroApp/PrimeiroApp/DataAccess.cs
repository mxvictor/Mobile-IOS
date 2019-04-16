using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using SQLite;
using UIKit;
using static System.Net.Mime.MediaTypeNames;
using static CoreFoundation.DispatchSource;

namespace PrimeiroApp
{

    [Table("Filmes")]
    public class Filme
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Titulo { get; set; }

        public byte[] Icone { get; set; }

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
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AppFilmes.db3");

            if (db == null)
            {
                db = new SQLiteConnection(dbPath);
                db.CreateTable<Filme>();
            }

        }

        public void Cadastrar(List<Filme> FilmeListas)
        {
            db.InsertAll(FilmeListas);
        }

        public List<Filme> FilmesLista()
        {

            List<FilmeListaAdd> filme = new List<FilmeListaAdd>();
            FilmeListaAdd filme1 = new FilmeListaAdd();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "AppFilmes.db3");
            if (db == null)
            {
                db = new SQLiteConnection(dbPath);
            }

            return db.Query<Filme>("SELECT * FROM [Filmes]")as List<Filme>;
            }
        }
    }
