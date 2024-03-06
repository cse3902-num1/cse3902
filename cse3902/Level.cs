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

namespace cse3902
{
    public class Level
    {
        private Player player;
        private List<Room> rooms;
        private int roomIdx = 0;
    

        public Level(GameContent content, IController controller)
        {
            player = new Player(content);
            player.Position = new Vector2(100, 100);
            rooms = new List<Room>
            {
                new Room(content, @"TilesData/Tile0.xml", @"DoorsData/Room0Door.xml"),
                new Room(content, @"TilesData/Tile1.xml", @"DoorsData/Room1Door.xml"),
                new Room(content, @"TilesData/Tile2.xml", @"DoorsData/Room2Door.xml"),
                new Room(content, @"TilesData/Tile3.xml", @"DoorsData/Room3Door.xml"),
                new Room(content, @"TilesData/Tile4.xml", @"DoorsData/Room4Door.xml")

            };
            


        }

        public void Update(GameTime gameTime, KeyboardController controller, MouseController mouseController)
        {

            //add room update
            player.Update(gameTime, controller);
            rooms[roomIdx].Update(gameTime, controller);
            if (mouseController.isLeftClick())
            {
                roomIdx++;
                roomIdx %= rooms.Count;
            }
            if (mouseController.isRightClick())
            {
                roomIdx--;
                if (roomIdx < 0) roomIdx = rooms.Count - 1;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rooms[roomIdx].Draw(spriteBatch);
            player.Draw(spriteBatch);

        }
    }
}
