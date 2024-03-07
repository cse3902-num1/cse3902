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
        private Player player;
        private List<Room> rooms;
        private int roomIdx = 0;
    

        public Level(GameContent content)
        {
            rooms = new List<Room>
            {
                new Room(content, @"TilesData/Tile0.xml", @"DoorsData/Room0Door.xml", player),
                new Room(content, @"TilesData/Tile1.xml", @"DoorsData/Room1Door.xml", player),
                new Room(content, @"TilesData/Tile2.xml", @"DoorsData/Room2Door.xml", player),
                new Room(content, @"TilesData/Tile3.xml", @"DoorsData/Room3Door.xml", player),
                new Room(content, @"TilesData/Tile4.xml", @"DoorsData/Room4Door.xml", player)

            };

            player = new Player(content, rooms[0]);
            player.Position = new Vector2(100, 100);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {

            //add room update
            player.Update(gameTime, controllers);
            rooms.ForEach(r => r.Update(gameTime, controllers));
            foreach(Room r in rooms){
                r.Update(gameTime, controllers);
            }

            if (controllers.Any(c => c.isLeftClick()))
            {
                roomIdx++;
                roomIdx %= rooms.Count;
            }
            if (controllers.Any(c => c.isRightClick()))
            {
                roomIdx--;
                if (roomIdx < 0) roomIdx = rooms.Count - 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rooms[roomIdx].Draw(spriteBatch);
           
            rooms.ForEach(r => r.Draw(spriteBatch));
            player.Draw(spriteBatch);
        }
    }
}
