using MongoDB.Driver;
using PortourgalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAPI.Services
{
    public class DistritoService
    {
        private readonly IMongoCollection<Distrito> _distritos;

        public DistritoService(IPortourgalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _distritos = database.GetCollection<Distrito>(settings.DistritosCollectionName);
        }

        public List<Distrito> Get() =>
            _distritos.Find(distrito => true).ToList();

        public Distrito Get(string id) =>
           _distritos.Find<Distrito>(distrito=> distrito.Id == id).FirstOrDefault();

        public Distrito GetByNome(string nome) =>
            _distritos.Find<Distrito>(distrito => distrito.Nome == nome).FirstOrDefault();

        public Distrito Create(Distrito distrito)
        {
            _distritos.InsertOne(distrito);
            return distrito;
        }

        public void Update(string id, Distrito distritoIn) =>
            _distritos.ReplaceOne(distrito => distrito.Id == id, distritoIn);

        public void UpdateByNome(string nome, Distrito distritoIn) =>
            _distritos.ReplaceOne(distrito => distrito.Nome == nome, distritoIn);

        public void Remove(Distrito distritoIn) =>
            _distritos.DeleteOne(distrito => distrito.Id == distritoIn.Id);

        public void Remove(string id) =>
            _distritos.DeleteOne(distrito => distrito.Id == id);

        public void RemoveByNome(string nome) =>
            _distritos.DeleteOne(distrito => distrito.Nome == nome);
    }
}
