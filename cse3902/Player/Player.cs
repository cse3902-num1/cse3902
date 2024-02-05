using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{    
    public class Player : IPlayer
    {
        public Vector2 Position = Vector2.Zero;
        public Vector2 Velocity = Vector2.Zero;
        public IPlayerState State;
        public List<IItem> Items = new List<IItem>();

        public Player(Game1 game)
        {
            State = new PlayerStateIdle(game, this);
        }

        public void Update(GameTime gameTime)
        {
            State.Update(gameTime);
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

        public void UseItem(int idx)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }
    }
}
