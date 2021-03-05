namespace Supercell.Laser.Home.Database
{
    using System;
    using MongoDB.Driver;
    using Supercell.Laser.Logic;
    using Supercell.Laser.Titan.Debug;
    using Supercell.Laser.Home.Database.Tables;

    public class Mongo
    {
        private static IMongoClient Client;
        private static IMongoDatabase Database;

        public static IMongoCollection<Players> Players;
        public static IMongoCollection<Alliances> Alliances;
        public static void Initialize()
        {
            try
            {
                Mongo.Client = new MongoClient(LogicConfiguration.GetMongodbURL());
            }
            catch
            {
                Debugger.Error("Error while connecting to MongoDB!");
                Console.ReadLine();
                Environment.Exit(-1);
            }
            Mongo.Database = Mongo.Client.GetDatabase("Laser");

            Mongo.Alliances = Mongo.Database.GetCollection<Alliances>("Alliances");
            Mongo.Players = Mongo.Database.GetCollection<Players>("Players");

            Mongo.Players.Indexes.CreateOne(Builders<Players>.IndexKeys.Combine(Builders<Players>.IndexKeys.Ascending(T => T.HighId), Builders<Players>.IndexKeys.Descending(T => T.LowId)),
            new CreateIndexOptions
            {
                Name = "entityIds",
                Background = true
            });

            Mongo.Alliances.Indexes.CreateOne(Builders<Alliances>.IndexKeys.Combine(Builders<Alliances>.IndexKeys.Ascending(T => T.HighId), Builders<Alliances>.IndexKeys.Descending(T => T.LowId)),
            new CreateIndexOptions
            {
                Name = "entityIds",
                Background = true
            });
        }
    }
}
