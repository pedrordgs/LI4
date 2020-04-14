using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace PortourgalAPI.Models
{
    public class Distrito
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }  
        public string Nome { get; set; }
        public string Historia { get; set; }
        public List<Cidade> Cidades { get; set; }
    }
}
