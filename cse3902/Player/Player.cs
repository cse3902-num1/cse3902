using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using cse3902.Interfaces;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.WallClasses;

namespace cse3902
{    
    public class Player : IPlayer
    {
        public Room CurrentRoom {set;get;}
        public Vector2 Position {set;get;} = Vector2.Zero;
        public Direction Facing {set;get;}
        public ICollider Pushbox {set;get;}
        public IPlayerState State;
        public int health = 5;
        public Player(GameContent content)
        {
            State = new PlayerStateIdle(content,this);
            Pushbox = new BoxCollider(Position,new Vector2(16,16), new Vector2(8, 8), ColliderType.PLAYER);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (controllers.Any(c => c.isPlayerTakeDamageJustPressed()))
            {
                TakeDamage();
            }

            State.Update(gameTime, controllers);

            Pushbox.Position = Position;
            foreach ( Wall wall in CurrentRoom.wall){

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {   
            State.Draw(spriteBatch);
        }

        public void Move(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        /* Sets the current item, which is used by PlayerStateItem. */
        public void UseItem(IInventoryItem item)
        {
            item.Use(this, CurrentRoom);
        }

        public void TakeDamage()
        {
            if(health > 0)
            {
                health -= 1;
            
                Debug.WriteLine("player health is: " + health);
            }
            if(health == 0)
            {
                Debug.WriteLine("YOU ARE DEAD!!!!!");
            }
        }
    }
}
