using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using cse3902.RoomClasses;
using System;
using cse3902.DoorClasses;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace cse3902
{
    public class Level
    {
        private const int HUD_HEIGHT = 40; // Adjust as needed
        public Player player;
        private List<Room> rooms;
        private int roomIdx = 0;
       

        public Level(GameContent content)
        {
            player = new Player(content);
            player.Position = new Vector2(300, 200);

            rooms = new List<Room>
            {
                new Room(content, @"TilesData/Tile0.xml", @"DoorsData/Room0Door.xml", player),
                new Room(content, @"TilesData/Tile1.xml", @"DoorsData/Room1Door.xml", player),
                new Room(content, @"TilesData/Tile2.xml", @"DoorsData/Room2Door.xml", player),
                new Room(content, @"TilesData/Tile3.xml", @"DoorsData/Room3Door.xml", player),
                new Room(content, @"TilesData/Tile4.xml", @"DoorsData/Room4Door.xml", player)

            };

            player.CurrentRoom = rooms[0];
            Sprite hud = new Sprite(content.hud, new List<Rectangle>() {
                 new Rectangle(258 ,11 ,256 ,56) },
                 new Vector2(8, 8),
                 3.0f);
           
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            player.Update(gameTime, controllers);

            rooms[roomIdx].Update(gameTime, controllers);

            if (controllers.Any(c => c.isLeftClick()))
            {
                roomIdx++;
                roomIdx %= rooms.Count;
                player.CurrentRoom = rooms[roomIdx];
            }
            if (controllers.Any(c => c.isRightClick()))
            {
                roomIdx--;
                if (roomIdx < 0) roomIdx = rooms.Count - 1;
                player.CurrentRoom = rooms[roomIdx];
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rooms[roomIdx].Draw(spriteBatch);
           
            player.Draw(spriteBatch);
            DrawHUD(spriteBatch);

        }

        private void DrawHUD(SpriteBatch spriteBatch)
        {

        }
    }
}
