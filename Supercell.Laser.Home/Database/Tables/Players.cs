namespace Supercell.Laser.Home.Database.Tables
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Players
    {
        [BsonId] public ObjectId Id;

        public int HighId;

        public int LowId;

        public BsonDocument Player;
    }
}
