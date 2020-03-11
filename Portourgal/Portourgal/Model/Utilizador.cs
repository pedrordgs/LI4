using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portourgal.Model
{
    class Utilizador
    {
        public Utilizador()
        {
            this.Nome = "";
            this.Cidade = "";
            this.Distrito = "";
            this.Email = "";
            this.Password = "";
        }

        public Utilizador(String n, String c, String d, String m, String p)
        {
            this.Nome = n;
            this.Cidade = c;
            this.Distrito = d;
            this.Email = m;
            this.Password = p;
        }

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Distrito { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void AddToDatabase()
        {
            MongoClient client = new MongoClient("mongodb://li4:li4@cluster0-shard-00-00-lscfy.gcp.mongodb.net:27017,cluster0-shard-00-01-lscfy.gcp.mongodb.net:27017,cluster0-shard-00-02-lscfy.gcp.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");
            var database = client.GetDatabase("PortourgalDB");
            var collection = database.GetCollection<BsonDocument>("Users");
            var document = new BsonDocument {{ "nome", Nome }, { "cidade", Cidade }, { "distrito", Distrito }, { "email", Email }, { "password", Password } };
            collection.InsertOne(document);
        }
    }
}
