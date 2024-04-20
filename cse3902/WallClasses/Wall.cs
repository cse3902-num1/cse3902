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
        private float wallScale = 3.0f;
        public Wall(GameContent content, Room room, Vector2 roomPosition)
        {
            walls = new List<Sprite>() {
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect1 }, wallScale),
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect2 }, wallScale),
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect3 }, wallScale),
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect4 }, wallScale),
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect5 }, wallScale),
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect6 }, wallScale),
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect7}, wallScale),
                new Sprite(content.walls, new List<Rectangle>() { WallConstant.wallSourceRect8}, wallScale)
            };
            // Vector2 offset = new Vector2(50, 300) + roomPosition;
            Vector2 offset = roomPosition;
            walls[0].Position = WallConstant.positionOffset1 + offset;
            walls[1].Position = WallConstant.positionOffset2 + offset;
            walls[2].Position = WallConstant.positionOffset3 + offset;
            walls[3].Position = WallConstant.positionOffset4 + offset;
            walls[4].Position = WallConstant.positionOffset5 + offset;
            walls[5].Position = WallConstant.positionOffset6 + offset;
            walls[6].Position = WallConstant.positionOffset7 + offset;
            walls[7].Position = WallConstant.positionOffset8 + offset;
            
            colliders = new List<BoxCollider>()
            {
                new BoxCollider(walls[0].Position+WallConstant.colliderOffsetLarge,WallConstant.colliderSizeLarge,WallConstant.colliderOriginLarge,ColliderType.WALL),
                new BoxCollider(walls[1].Position+WallConstant.colliderOffset,WallConstant.colliderSize,WallConstant.colliderOrigin,ColliderType.WALL),
                new BoxCollider(walls[2].Position + WallConstant.colliderOffsetLarge,WallConstant.colliderSizeLarge,WallConstant.colliderOriginLarge,ColliderType.WALL),
                new BoxCollider(walls[3].Position + WallConstant.colliderOffset,WallConstant.colliderSize,WallConstant.colliderOrigin,ColliderType.WALL),
                new BoxCollider(walls[4].Position + WallConstant.colliderOffset ,WallConstant.colliderSize,WallConstant.colliderOrigin,ColliderType.WALL),
                new BoxCollider(walls[5].Position + WallConstant.colliderOffsetLarge,WallConstant.colliderSizeLarge,WallConstant.colliderOriginLarge,ColliderType.WALL),
                new BoxCollider(walls[6].Position + WallConstant.colliderOffset,WallConstant.colliderSize,WallConstant.colliderOrigin,ColliderType.WALL),
                new BoxCollider(walls[7].Position + WallConstant.colliderOffsetLarge,WallConstant.colliderSizeLarge,WallConstant.colliderOriginLarge,ColliderType.WALL),

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
