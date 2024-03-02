using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{    
    public class Player : IPlayer
    {
        public Vector2 Position {set;get;} = Vector2.Zero;
        public Direction Facing {set;get;}
        public ICollider collider;
        public IPlayerState State;
        private List<IProjectile> projectiles;
        private int health = 5;
        public Player(GameContent content)
        {
            State = new PlayerStateIdle(content,this);
            projectiles = new List<IProjectile>();
        }

        public void Update(GameTime gameTime, IController controller)
        {
            if (controller.isPlayerTakeDamageJustPressed() )
            {
                TakeDamage();
            }

            State.Update(gameTime, controller);

            projectiles.ForEach(p => p.Update(gameTime, controller));

            /* remove dead projectiles */
            projectiles = projectiles.Where(p => !p.IsDead).ToList();
        }

        public void Draw(SpriteBatch spriteBatch)
        {   
            State.Draw(spriteBatch);

            foreach (IProjectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }
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
            item.Use(this);
        }

        public void SpawnProjectile(IProjectile projectile)
        {
            projectiles.Add(projectile);
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
