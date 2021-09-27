using System.Collections.Generic;

namespace Repository
{
    internal class GameModel
    {
        public GameModel()
        {
        }

        public GameModel(FieldModel field, GameObjectModel starship, List<GameObjectModel> aliens,
            List<GameObjectModel> bullets)
        {
            Field = field;
            Starship = starship;
            Aliens = aliens;
            Bullets = bullets;
        }

        public GameObjectModel Starship { get; set; }
        public FieldModel Field { get; set; }

        public List<GameObjectModel> Aliens { get; set; }
        public List<GameObjectModel> Bullets { get; set; }
    }
}