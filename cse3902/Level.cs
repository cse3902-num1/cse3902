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
        private List<List<Room>> rooms; /* 2d array of rooms, indexed x first then y */
        private int currentRoomX = 0;
        private int currentRoomY = 0;
        private int newRoomX = 0;
        private int newRoomY = 0;
       

        public Level(GameContent content)
        {
            player = new Player(content);
            player.Position = new Vector2(300, 300);

            /* initialize rooms 2d array. null values mean there's no room there */
            const int MAX_ROOMS_HORIZONTAL = 6;
            const int MAX_ROOMS_VERTICAL = 6;
            rooms = new List<List<Room>>();
            for (int x = 0; x < MAX_ROOMS_HORIZONTAL; x++) {
                rooms.Add(new List<Room>());
                for (int y = 0; y < MAX_ROOMS_VERTICAL; y++) {
                    rooms[x].Add(null);
                }
            }

            /* new rooms */
            AddRoom(0, 0, content, @"TilesData/Tile0.xml", @"DoorsData/Room0Door.xml", player);
            AddRoom(1, 0, content, @"TilesData/Tile1.xml", @"DoorsData/Room1Door.xml", player);
            AddRoom(2, 0, content, @"TilesData/Tile2.xml", @"DoorsData/Room2Door.xml", player);
            AddRoom(0, 1, content, @"TilesData/Tile3.xml", @"DoorsData/Room3Door.xml", player);
            AddRoom(1, 1, content, @"TilesData/Tile4.xml", @"DoorsData/Room4Door.xml", player);

            // rooms = new List<Room>
            // {
            //     new Room(content, new Vector2(0 * Room.ROOM_WIDTH, 0 * Room.ROOM_HEIGHT), @"TilesData/Tile0.xml", @"DoorsData/Room0Door.xml", player),
            //     new Room(content, new Vector2(1 * Room.ROOM_WIDTH, 0 * Room.ROOM_HEIGHT), @"TilesData/Tile1.xml", @"DoorsData/Room1Door.xml", player),
            //     new Room(content, new Vector2(0 * Room.ROOM_WIDTH, 1 * Room.ROOM_HEIGHT), @"TilesData/Tile2.xml", @"DoorsData/Room2Door.xml", player),
            //     new Room(content, new Vector2(1 * Room.ROOM_WIDTH, 1 * Room.ROOM_HEIGHT), @"TilesData/Tile3.xml", @"DoorsData/Room3Door.xml", player),
            //     new Room(content, new Vector2(-1 * Room.ROOM_WIDTH, 0 * Room.ROOM_HEIGHT), @"TilesData/Tile4.xml", @"DoorsData/Room4Door.xml", player)
            // };

            currentRoomX = 0;
            currentRoomY = 0;
            player.CurrentRoom = rooms[0][0];
       
            EventBus.EnteringDoor += OnEnteringDoor;
            EventBus.EndingRoomTransition += OnEndingRoomTransition;
        }

        private void AddRoom(int x, int y, GameContent content, String xmlFilePath, String doorFilePath, Player player)
        {
            rooms[x][y] = new Room(
                content,
                new Vector2(x * Room.ROOM_WIDTH, y * Room.ROOM_HEIGHT),
                xmlFilePath,
                doorFilePath,
                player
            );
        }

        private void OnEnteringDoor(Direction direction)
        {
            newRoomX = currentRoomX;
            newRoomY = currentRoomY;
            switch (direction) {
                case Direction.Left:
                    newRoomX -= 1;
                    break;
                case Direction.Right:
                    newRoomX += 1;
                    break;
                case Direction.Up:
                    newRoomY -= 1;
                    break;
                case Direction.Down:
                    newRoomY += 1;
                    break;
            }
            if (newRoomX < 0) newRoomX = 0;
            if (newRoomX >= rooms.Count) newRoomX = rooms.Count - 1;
            if (newRoomY < 0) newRoomY = 0;
            if (newRoomY >= rooms[newRoomX].Count) newRoomY = rooms[newRoomX].Count - 1;

            Room currentRoom = rooms[currentRoomX][currentRoomY];
            Room nextRoom = rooms[newRoomX][newRoomY];
            EventBus.StartingRoomTransition(currentRoom, nextRoom);

            // if (currentRoomX < 0) currentRoomX = 0;
            // if (currentRoomX >= rooms.Count) currentRoomX = rooms.Count - 1;
            // if (currentRoomY < 0) currentRoomY = 0;
            // if (currentRoomY >= rooms[currentRoomX].Count) currentRoomY = rooms[currentRoomX].Count - 1;
            // player.CurrentRoom = rooms[currentRoomX][currentRoomY];
        }

        public void OnEndingRoomTransition()
        {
            currentRoomX = newRoomX;
            currentRoomY = newRoomY;
            player.CurrentRoom = rooms[currentRoomX][currentRoomY];
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            player.Update(gameTime, controllers);

            // TODO: only update current room, and provide a way to transition between rooms
            rooms[currentRoomX][currentRoomY].Update(gameTime, controllers);
            // rooms.ForEach(r => r.Update(gameTime, controllers));

            // if (controllers.Any(c => c.isLeftClick()))
            // {
            //     roomIdx++;
            //     roomIdx %= rooms.Count;
            //     player.CurrentRoom = rooms[roomIdx];
            // }
            // if (controllers.Any(c => c.isRightClick()))
            // {
            //     roomIdx--;
            //     if (roomIdx < 0) roomIdx = rooms.Count - 1;
            //     player.CurrentRoom = rooms[roomIdx];
            // }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<Room> column in rooms) {
                foreach (Room room in column) {
                    if (room == null) continue;
                    room.Draw(spriteBatch);
                }
            }
           
            player.Draw(spriteBatch);
            DrawHUD(spriteBatch);

        }

        private void DrawHUD(SpriteBatch spriteBatch)
        {

        }
    }
}
