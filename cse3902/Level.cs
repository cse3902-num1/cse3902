using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using cse3902.RoomClasses;
using cse3902.PlayerClasses;
using System;
using cse3902.DoorClasses;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace cse3902
{
    public class Level
    {
      
        public Player player;
        private List<Room> rooms;
        private int roomIdx = 0;
       

        public Level(GameContent content)
        {
            player = new Player(content);
            player.Position = new Vector2(300, 600);

            int ROOM_WIDTH = 768;
            int ROOM_HEIGHT = 528;
            rooms = new List<Room>
            {
                new Room(content, new Vector2(0 * ROOM_WIDTH, 0 * ROOM_HEIGHT), @"TilesData/Tile0.xml", @"DoorsData/Room0Door.xml", player),
                new Room(content, new Vector2(1 * ROOM_WIDTH, 0 * ROOM_HEIGHT), @"TilesData/Tile1.xml", @"DoorsData/Room1Door.xml", player),
                new Room(content, new Vector2(0 * ROOM_WIDTH, 1 * ROOM_HEIGHT), @"TilesData/Tile2.xml", @"DoorsData/Room2Door.xml", player),
                new Room(content, new Vector2(1 * ROOM_WIDTH, 1 * ROOM_HEIGHT), @"TilesData/Tile3.xml", @"DoorsData/Room3Door.xml", player),
                new Room(content, new Vector2(-1 * ROOM_WIDTH, 0 * ROOM_HEIGHT), @"TilesData/Tile4.xml", @"DoorsData/Room4Door.xml", player)

            };

            player.CurrentRoom = rooms[0];
       
           
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            player.Update(gameTime, controllers);

            // rooms[roomIdx].Update(gameTime, controllers);
            // TODO: only update current room, and provide a way to transition between rooms
            rooms.ForEach(r => r.Update(gameTime, controllers));

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
            rooms.ForEach(r => r.Draw(spriteBatch));
           
            player.Draw(spriteBatch);
            DrawHUD(spriteBatch);

        }

        private void DrawHUD(SpriteBatch spriteBatch)
        {

        }
    }
}
