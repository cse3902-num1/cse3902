using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{    
    public class Player : IPlayer
    {
        public Vector2 Position = Vector2.Zero;
        public Direction Facing;
        public IPlayerState State;
        public IItemPickup Item;
        public KeyboardController Controller;
        private int health = 5;
        private int timeDamaged = 0;
        public Player(GameContent content)
        {
            State = new PlayerStateIdle(content,this);

        }

        public void Update(GameTime gameTime, IController controller)
        {
            State.Update(gameTime, controller);
            if (controller.isDamaged() )
            {
                TakeDamage();
                
            }
            /* TODO: take damage if damage player button is pressed */
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
        public void UseItem(int idx)
        {
            /* TODO: finish this once item classes are done */
            if (idx == 0)
            {
                // this.Item = new ExampleItem();
            }
            else if (idx == 1)
            {
                // this.Item = new ExampleItem();
            }
            else if (idx == 2)
            {
                // this.Item = new ExampleItem();
            }
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
