using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Core;

namespace Repository
{
    public class FileRepository
    {
        public void SaveGame(Game game)
        {
            var starship = new GameObjectModel(game.Starship.Body, game.Starship.Position.X, game.Starship.Position.Y);
            var field = new FieldModel(game.Field.Width, game.Field.Height, game.Field.BackGround);
            var aliens = new List<GameObjectModel>();
            foreach (var alien in game.Aliens)
                aliens.Add(new GameObjectModel(alien.Body, alien.Position.X, alien.Position.Y));
            var bullets = new List<GameObjectModel>();
            foreach (var bullet in game.Bullets)
                bullets.Add(new GameObjectModel(bullet.Body, bullet.Position.X, bullet.Position.Y));
            var gameModel = new GameModel(field, starship, aliens, bullets);
            var gameBytes = JsonSerializer.SerializeToUtf8Bytes(gameModel);
            var gameFile = File.Create("game.json");
            gameFile.Write(gameBytes, 0, gameBytes.Length);
            gameFile.Close();
        }


        public Game LoadGame()
        {
            if (!File.Exists("game.json"))
                return null;
            var gameString = File.ReadAllText("game.json");
            var gameModel = JsonSerializer.Deserialize<GameModel>(gameString);
            var field = new Field(gameModel.Field.Width, gameModel.Field.Height, gameModel.Field.BackGround);
            var starship = new GameObject(gameModel.Starship.Body, gameModel.Starship.X, gameModel.Starship.Y);
            var aliens = new List<GameObject>();
            foreach (var alien in gameModel.Aliens) aliens.Add(new GameObject(alien.Body, alien.X, alien.Y));
            var bullets = new List<GameObject>();
            foreach (var bullet in gameModel.Bullets) bullets.Add(new GameObject(bullet.Body, bullet.X, bullet.Y));

            return new Game(field, starship, aliens, bullets);
        }
    }
}