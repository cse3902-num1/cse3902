using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace cse3902
{
    public class Gel : IEnemy
    {
        //private ISprite sprite;
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        private float timer = 0;
        private int threshold = 75;
        private byte previousAnimationIndex = 2;
        private byte currentAnimationIndex = 1;
        private float x = 200, y = 200;
        private Stopwatch randomChangeTimer = new Stopwatch();
        private Random random = new Random();
        private int randomNum = 1;
        public bool isVisible = false;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public Gel(ContentManager content)
        {
            //sprite = new Sprite();
            sourceRectangles = new Rectangle[2];
            sourceRectangles[0] = new Rectangle(1, 11, 7, 16);
            sourceRectangles[1] = new Rectangle(10, 11, 7, 16);

            texture = content.Load<Texture2D>("enemiesSheet");
        }

        public void move(GameTime gameTime, int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    //sprite.moveUp();
                    y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 2:
                    //sprite.moveLeft();
                    x -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 3:
                    //sprite.moveRight();
                    x += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case 4:
                    //sprite.moveDown();
                    y += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void attack()
        {

        }

        public void takeDmg()
        {

        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture,
                    new Vector2(x, y),
                    sourceRectangles[currentAnimationIndex],
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    3f,
                    SpriteEffects.None, 1f
                );
            }
        }

        public void update(GameTime gameTime)
        {

            randomChangeTimer.Start();

            if (randomChangeTimer.ElapsedMilliseconds >= 500)
            {
                randomChangeTimer.Restart();

                randomNum = random.Next(1, 5);
            }

            move(gameTime, randomNum);


            if (timer > threshold)
            {
                if (currentAnimationIndex == 0)
                {
                    currentAnimationIndex = 1;
                }
                else
                {
                    currentAnimationIndex = 0;
                }

                timer = 0;
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
