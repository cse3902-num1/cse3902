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
        public List<BoxCollider> colliders;

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
            Vector2 offset = new Vector2(50, 300);

            topDoors = new List<Sprite>()
            {
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) + offset },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) + offset },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) + offset },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) + offset },
                new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 0) + offset }
            };
            botDoors = new List<Sprite>()
            {
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) + offset },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) + offset },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) + offset },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) + offset },
                new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(336, 432) + offset }
            };
            leftDoors = new List<Sprite>()
            {
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) + offset },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) + offset },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) + offset },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) + offset },
                new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(0, 216) + offset }
            };
            rightDoors = new List<Sprite>()
            {
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(0, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) + offset },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(32, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) + offset },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(64, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) + offset },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(96, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) + offset },
                new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(128, 0, 32, 32) }, 3.0f) { Position = new Vector2(672, 216) + offset }
            };
            this.idx = idx;
            colliders = new List<BoxCollider>()
            {
                new BoxCollider(topDoors[0].Position+new Vector2(16, 16)*3, new Vector2(32, 32)*3, new Vector2(16, 16)*3, ColliderType.DOOR),
                new BoxCollider(botDoors[0].Position+new Vector2(16, 16)*3, new Vector2(32, 32)*3, new Vector2(16, 16)*3, ColliderType.DOOR),
                new BoxCollider(leftDoors[0].Position + new Vector2(16, 16) * 3, new Vector2(32, 32)*3, new Vector2(16, 16)*3, ColliderType.DOOR),
                new BoxCollider(rightDoors[0].Position + new Vector2(16, 16) * 3, new Vector2(32, 32)*3, new Vector2(16, 16)*3, ColliderType.DOOR)
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
