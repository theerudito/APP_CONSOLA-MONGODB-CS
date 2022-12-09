// unirme al namespace de la clase
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDB_APP.Models
{
  // Crear una clase
  public class Naruto
  {
    // Crear propiedades
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("clan")]
    public string Clan { get; set; }

    [BsonElement("age")]
    public string Age { get; set; }
  }
}