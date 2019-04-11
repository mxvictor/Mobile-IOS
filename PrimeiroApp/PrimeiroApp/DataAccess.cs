using System;
using System.Data;
using System.IO;
using SQLite;
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
        public DataAccess()
        {
        }
    }
}
