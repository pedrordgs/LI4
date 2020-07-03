using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAPI.Models
{
    public class Roteiro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<string> Percurso { get; set; }
        public string Descricao { get; set; }
        public string ImagemRoteiro { get; set; }
        public string ImagemPercurso { get; set; }
        public string Nome { get; set; }
        public int Dist { get; set; }
    }
}
