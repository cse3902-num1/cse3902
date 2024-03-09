using System;
using System.Collections.Generic;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.WallClasses
{
    public class Wall
    {
        private List<Sprite> walls;
        protected Room room;
        public List<BoxCollider> colliders;

        public Wall(GameContent content, Room room)
        {
            walls = new List<Sprite>() {
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(0, 0, 112, 32) }, 3.0f),
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(0, 32, 32, 40) }, 3.0f),
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(144, 0, 112, 32) }, 3.0f),
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(224, 32, 32, 40) }, 3.0f),
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(0, 104, 32, 40) }, 3.0f),
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(0, 144, 112, 32) }, 3.0f),
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(224, 104, 32, 40) }, 3.0f),
                new Sprite(content.walls, new List<Rectangle>() { new Rectangle(144, 144, 112, 32) }, 3.0f)
            };
            walls[0].Position = new Vector2(0, 0);
            walls[1].Position = new Vector2(0, 96);
            walls[2].Position = new Vector2(432, 0);
            walls[3].Position = new Vector2(672, 96);
            walls[4].Position = new Vector2(0, 312);
            walls[5].Position = new Vector2(0, 432);
            walls[6].Position = new Vector2(672, 312);
            walls[7].Position = new Vector2(432, 432);
            colliders = new List<BoxCollider>()
            {
                new BoxCollider(walls[0].Position+new Vector2(56,16)*3,new Vector2(112,32)*3,new Vector2(56,16)*3,ColliderType.WALL),
                new BoxCollider(walls[1].Position+new Vector2(16,20)*3,new Vector2(32, 40)*3,new Vector2(16,20)*3,ColliderType.WALL),
                new BoxCollider(walls[2].Position+new Vector2(56,16)*3,new Vector2(112,32)*3,new Vector2(56,16)*3,ColliderType.WALL),
                new BoxCollider(walls[3].Position+new Vector2(16,20)*3,new Vector2(32, 40)*3,new Vector2(16,20)*3,ColliderType.WALL),
                new BoxCollider(walls[4].Position+new Vector2(16,20)*3,new Vector2(32, 40)*3,new Vector2(16,20)*3,ColliderType.WALL),
                new BoxCollider(walls[5].Position+new Vector2(56,16)*3,new Vector2(112,32)*3,new Vector2(56,16)*3,ColliderType.WALL),
                new BoxCollider(walls[6].Position+new Vector2(16,20)*3,new Vector2(32, 40)*3,new Vector2(16,20)*3,ColliderType.WALL),
                new BoxCollider(walls[7].Position+new Vector2(56,16)*3,new Vector2(112,32)*3,new Vector2(56,16)*3,ColliderType.WALL),

            };
            this.room = room;

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            for(int i = 0; i < walls.Count; i++) {
                walls[i].Draw(spriteBatch);
            }
        }
    }
}
