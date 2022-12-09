using MongoDB.Driver;

namespace MongoDB_APP
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("'Hello World!'");

      // el cliente de mongo
      var clientMongoDB = new MongoClient("mongodb://localhost:27017");
      // la db de mongo
      var dbMongoDB = clientMongoDB.GetDatabase("Naruto");
      // la coleccion de mongo
      var collectionMongoDB = dbMongoDB.GetCollection<Models.Naruto>("characters");


      //=============== ADD DOCUMENT IN COLLECTION =================================================================
      var naruto = new Models.Naruto
      {
        Name = "Naruto",
        Clan = "Uzumaki",
        Age = "12"
      };

      collectionMongoDB.InsertOne(naruto);
      //=============== ADD DOCUMENT IN COLLECTION =================================================================


      //=============== GET ALL DOCUMENTS IN COLLECTION =============================================================
      var characters = collectionMongoDB.Find(character => true).ToList();
      System.Console.WriteLine(characters);
      //=============== GET ALL DOCUMENTS IN COLLECTION =============================================================



      //=============== GET ONE DOCUMENT IN COLLECTION ==============================================================
      var character = collectionMongoDB.Find(character => character.Name == "Naruto Uzumaki").FirstOrDefault();
      System.Console.WriteLine(character.Name);
      //=============== GET ONE DOCUMENT IN COLLECTION ==============================================================



      //=============== UPDATE DOCUMENT IN COLLECTION ==============================================================
      var updateCharacter = new Models.Naruto
      {
        Id = "63935779f307668fdf7be383",
        Name = "Naruto",
        Clan = "Uzumaki",
        Age = "12"
      };
      collectionMongoDB.ReplaceOne(character => character.Id == "63935779f307668fdf7be383", updateCharacter);
      //=============== UPDATE DOCUMENT IN COLLECTION ==============================================================



      //=============== DELETE DOCUMENT IN COLLECTION ==============================================================
      collectionMongoDB.DeleteOne(character => character.Id == "63935779f307668fdf7be383");
      //=============== DELETE DOCUMENT IN COLLECTION ==============================================================

    }
  }
}
