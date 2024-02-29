using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.DoorClasses
{
    public class Doors
    {
        private List<Sprite> doors;

        public Doors(GameContent content)
        {

            doors = new List<Sprite>() {
             new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) },
           new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) },
              new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) },
               new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) },

        };
        }

        /* public bool IsColliding(ICollider collider)
         {
             if (!ColliderType.CollidesWith(collider.ColliderType)) return false;
             return collider is BoxCollider boxCollider && this.Rectangle.Intersects(boxCollider.rectangle);
         }
        */

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var door in doors)
            {
                door.Draw(spriteBatch);
            }
        }
    }
}
