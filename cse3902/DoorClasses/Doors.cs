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

        public Doors(GameContent content, int idx, int doorType, Vector2 roomPosition)
        {
            this.idx = idx;
            this.doorType = doorType;
            int offsetX = 50;
            int offsetY = 300;

            Vector2 offset = new Vector2(offsetX, offsetY);
            int doorXOffset = 32;
            Vector2 topDoorPosition = Constant.TopDoorPosition + offset + roomPosition;
            Vector2 botDoorPosition = Constant.BottomDoorPosition + offset + roomPosition;
            Vector2 leftDoorPosition = Constant.LeftDoorPosition + offset + roomPosition;
            Vector2 rightDoorPosition = Constant.RightDoorPosition + offset + roomPosition;

            topDoors = new List<Sprite>();
            for (int i = 0; i < 5; i++) {
                topDoors.Add( new Sprite(content.topDoors, new List<Rectangle>() { new Rectangle(doorXOffset * i, 0, Constant.DoorWidth, Constant.DoorHeight) }, Constant.DoorScale) { Position = topDoorPosition });     
            }


            botDoors = new List<Sprite>();
            for (int i = 0; i < 5; i++)
            {
                botDoors.Add(new Sprite(content.bottomDoors, new List<Rectangle>() { new Rectangle(doorXOffset * i, 0, Constant.DoorWidth, Constant.DoorHeight) }, Constant.DoorScale) { Position = botDoorPosition });
            }

            leftDoors = new List<Sprite>();
            for (int i = 0; i < 5; i++)
            {
                leftDoors.Add(new Sprite(content.leftDoors, new List<Rectangle>() { new Rectangle(doorXOffset * i, 0, Constant.DoorWidth, Constant.DoorHeight) }, Constant.DoorScale) { Position = leftDoorPosition });
            }
            rightDoors = new List<Sprite>();
            for (int i = 0; i < 5; i++)
            {
                rightDoors.Add(new Sprite(content.rightDoors, new List<Rectangle>() { new Rectangle(doorXOffset * i, 0, Constant.DoorWidth, Constant.DoorHeight) }, Constant.DoorScale) { Position = rightDoorPosition });
            }
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
