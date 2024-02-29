using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;
using cse3902.RoomClasses;
using System;

namespace cse3902
{
    public class Level
    {
        private Player player;
        private List<Room> rooms;
    

        public Level(GameContent content, IController controller)
        {
            player = new Player(content);
            player.Position = new Vector2(100, 100);

             
        }

        public void Update(GameTime gameTime, IController controller)
        {
           
            //add room update
            player.Update(gameTime, controller);
            /*foreach(Room r in rooms){
                r.Update(gameTime, controller);
            }
            */
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            /*foreach (Room r in rooms)
            {
                r.Draw(spriteBatch);
            }*/

        }
    }
}
