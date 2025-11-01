
namespace SteamRandomizer.src.Model
{
    public class Game
    {
        //[BsonId]
        //public ObjectId MongoId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ImagePath { get; set; }
    }
}
