using MongoDB.Driver;
using PortourgalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAPI.Services
{
    public class RoteiroService
    {
        private readonly IMongoCollection<Roteiro> _roteiros;

        public RoteiroService(IPortourgalDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _roteiros = database.GetCollection<Roteiro>(settings.RoteirosCollectionName);
        }

        public List<Roteiro> Get() =>
            _roteiros.Find(rot => true).ToList();

        public Roteiro Get(string id) =>
           _roteiros.Find<Roteiro>(rot => rot.Id == id).FirstOrDefault();

        public Roteiro GetByNome(string nome) =>
            _roteiros.Find<Roteiro>(rot => rot.Nome == nome).FirstOrDefault();

        public Roteiro Create(Roteiro rot)
        {
            _roteiros.InsertOne(rot);
            return rot;
        }

        public void Update(string id, Roteiro rotIn) =>
            _roteiros.ReplaceOne(rot => rot.Id == id, rotIn);

        public void UpdateByNome(string nome, Roteiro rotIn) =>
            _roteiros.ReplaceOne(rot => rot.Nome == nome, rotIn);

        public void Remove(Roteiro rotIn) =>
            _roteiros.DeleteOne(rot => rot.Id == rotIn.Id);

        public void Remove(string id) =>
            _roteiros.DeleteOne(rot => rot.Id == id);

        public void RemoveByNome(string nome) =>
            _roteiros.DeleteOne(rot => rot.Nome == nome);

    }
}
