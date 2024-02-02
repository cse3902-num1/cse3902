using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class Skeleton : IEnemy
    {
        ISprite sprite;

        public Skeleton(ContentManager content)
        {
            sprite = new Sprite();
            sprite.texture = content.Load<Texture2D>("enemies");
        }

        public void move()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 4);
            switch (randomNum)
            {
                case 1:
                    sprite.moveUp();
                    break;
                case 2:
                    sprite.moveLeft();
                    break;
                case 3:
                    sprite.moveRight();
                    break;
                case 4:
                    sprite.moveDown();
                    break;
            }
        }

        public void attack()
        {
            // Skeleton does not attack
        }

        public void takeDmg()
        {

        }
    }
}
