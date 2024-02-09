using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class Goriya : IEnemy
    {
        //private ISprite sprite;
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        private float timer = 0;
        private int threshold = 250;
        private int currentIdx = 0;
        private byte previousAnimationIndex = 3;
        private byte currentAnimationIndex = 2;
        private float x = 200, y = 200;
        private Stopwatch randomChangeTimer = new Stopwatch();
        private Random random = new Random();
        private int randomNum = 1;
        private bool flipped = false;
        private enum GoriyaState { Left, Right, Up, Down }
        private GoriyaState state;
        public bool isVisible = false;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public Goriya(ContentManager content)
        {
            //sprite = new Sprite();
            sourceRectangles = new Rectangle[4];
            sourceRectangles[0] = new Rectangle(222, 11, 16, 16);
            sourceRectangles[1] = new Rectangle(239, 11, 16, 16);
            sourceRectangles[2] = new Rectangle(256, 11, 16, 16);
            sourceRectangles[3] = new Rectangle(273, 11, 16, 16);
            texture = content.Load<Texture2D>("enemiesSheet");
        }

        public void move(GameTime gameTime, int randomNum)
        {
            switch (state)
            {
                case GoriyaState.Up:
                    //sprite.moveUp();
                    y -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case GoriyaState.Left:
                    //sprite.moveLeft();
                    x -= 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case GoriyaState.Right:
                    //sprite.moveRight();
                    x += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case GoriyaState.Down:
                    //sprite.moveDown();
                    y += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        public void changeDirection(int randomNum)
        {
            switch (randomNum)
            {
                case 1:
                    state = GoriyaState.Up;
                    currentIdx = 1;
                    break;
                case 2:
                    state = GoriyaState.Down;
                    currentIdx = 0;
                    break;
                case 3:
                    state = GoriyaState.Left;
                    currentIdx = 1;
                    break;
                case 4:
                    state = GoriyaState.Right;
                    currentIdx = 0;
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
                if (state == GoriyaState.Up || state == GoriyaState.Down)
                {
                    if (flipped)
                    {
                        spriteBatch.Draw(texture,
                            new Vector2(x, y),
                            sourceRectangles[currentIdx],
                            Color.White,
                            0f,
                            new Vector2(0, 0),
                            3f,
                            SpriteEffects.None,
                            1f
                        );
                    }
                    else
                    {
                        spriteBatch.Draw(texture,
                            new Vector2(x, y),
                            sourceRectangles[currentIdx],
                            Color.White,
                            0f,
                            new Vector2(0, 0),
                            3f,
                            SpriteEffects.FlipHorizontally,
                            1f
                        );
                    }
                }
                else if(state == GoriyaState.Right)
                {
                    spriteBatch.Draw(texture,
                            new Vector2(x, y),
                            sourceRectangles[currentAnimationIndex],
                            Color.White,
                            0f,
                            new Vector2(0, 0),
                            3f,
                            SpriteEffects.None,
                            1f
                        );
                }
                else
                {
                    spriteBatch.Draw(texture,
                            new Vector2(x, y),
                            sourceRectangles[currentAnimationIndex],
                            Color.White,
                            0f,
                            new Vector2(0, 0),
                            3f,
                            SpriteEffects.FlipHorizontally,
                            1f
                        );
                }
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

            changeDirection(randomNum);
            move(gameTime, randomNum);


            if (timer > threshold)
            {
                if (!flipped)
                {
                    flipped = true;
                }
                else
                {
                    flipped = false;
                }

                if (currentAnimationIndex == 2)
                {
                    currentAnimationIndex = 3;
                }
                else
                {
                    currentAnimationIndex = 2;
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
