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
        private List<Sprite> topDoors;
        private List<Sprite> botDoors;
        private List<Sprite> leftDoors;
        private List<Sprite> rightDoors;
        private int idx;
        private int doorType;

        public int Idx
        {
            get { return idx; }
            set { idx = value; }
        }

        public int DoorType
        {
            get { return doorType; }
            set { doorType = value; }
        }

        public Doors(GameContent content, int idx, int doorType)
        {
            this.idx = idx;
            this.doorType = doorType;

            topDoors = new List<Sprite>()
            {
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) }
            };
            botDoors = new List<Sprite>()
            {
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) }
            };
            leftDoors = new List<Sprite>()
            {
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) }
            };
            rightDoors = new List<Sprite>()
            {
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) }
            };
            this.idx = idx;
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
            switch(doorType)
            {
                case 0: topDoors[idx].Draw(spriteBatch); break;
                case 1: leftDoors[idx].Draw(spriteBatch); break;
                case 2: botDoors[idx].Draw(spriteBatch); break;
                case 3: rightDoors[idx].Draw(spriteBatch); break;
            }
        }
    }
}
