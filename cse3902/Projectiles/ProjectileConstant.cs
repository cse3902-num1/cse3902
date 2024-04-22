using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Projectiles
{
    public class ProjectileConstant
    {
        public const int BLUE_ARROW_DAMAGE = 2;
        public const int GREEN_ARROW_DAMAGE = 1;
        public const int MAGICAL_BOOMERANG_DAMAGE = 2;
        public const int GREEN_BOOMERANG_DAMAGE = 1;
        public const int FIRE_DAMAGE = 3;
        public const int FIREBALL_DAMAGE = 2;
        public const int BOMB_DAMAGE = 11; /* enough to kill everything in 1 hit except goriya and dragon */

        public static Rectangle BlueArrowLeftSourceRect = new Rectangle(0, 15, 15, 15);
        public static Rectangle BlueArrowRightSourceRect = new Rectangle(36, 185, 15, 15);
        public static Rectangle BlueArrowUpSourceRect = new Rectangle(27, 185, 7, 15);
        public static Rectangle BlueArrowDownSourceRect = new Rectangle(15, 15, 15, 15);
        public static Vector2 BlueArrowCollideSize = new Vector2(15, 15);
        public static Vector2 BlueArrowCollideOrigin = new Vector2(15, 15);

        public static Rectangle BombSourceRect = new Rectangle(129, 185, 7, 15);
        public static Vector2 BombCollideSize = new Vector2(7, 15);
        public static Vector2 BombCollideOrigin = new Vector2(3.5f, 7.5f);

        public static Rectangle FireAnimationSourceRect1 = new Rectangle(0, 30, 15, 15);
        public static Rectangle FireAnimationSourceRect2 = new Rectangle(15, 30, 15, 15);

        public static Vector2 FireCollideSize = new Vector2(15, 15);
        public static Vector2 FireCollideOrigin = new Vector2(7.5f, 7.5f);

        public static Rectangle FireBallAnimationSourceRect1 = new Rectangle(101, 14, 8, 10);
        public static Rectangle FireBallAnimationSourceRect2 = new Rectangle(110, 14, 8, 10);
        public static Rectangle FireBallAnimationSourceRect3 = new Rectangle(119, 14, 8, 10);
        public static Rectangle FireBallAnimationSourceRect4 = new Rectangle(128, 14, 8, 10);

        public static Vector2 FireBallCollideSize = new Vector2(8, 10);
        public static Vector2 FireBallCollideOrigin = new Vector2(4, 5);

        public static Rectangle GreenArrowLeftSourceRect = new Rectangle(0, 0, 15, 15);
        public static Rectangle GreenArrowRightSourceRect = new Rectangle(10, 185, 15, 15);
        public static Rectangle GreenArrowUpSourceRect = new Rectangle(1, 185, 7, 15);
        public static Rectangle GreenArrowDownSourceRect = new Rectangle(15, 0, 15, 15);

        public static Vector2 GreenArrowCollideSize = new Vector2(15, 15);
        public static Vector2 GreenArrowCollideOrigin = new Vector2(7.5f, 7.5f);


        public static Rectangle GreenBoomerangAnimationSourceRect1 = new Rectangle(290, 11, 8, 16);
        public static Rectangle GreenBoomerangAnimationSourceRect2 = new Rectangle(299, 11, 8, 16);
        public static Rectangle GreenBoomerangAnimationSourceRect3 = new Rectangle(308, 11, 8, 16);

        public static Vector2 GreenBoomerangCollideSize = new Vector2(8, 16);
        public static Vector2 GreenBoomerangCollideOrigin = new Vector2(4, 8);
        public static Rectangle MagicalBoomerangAnimationSourceRect1 = new Rectangle(0, 0, 20, 32);
        public static Rectangle MagicalBoomerangAnimationSourceRect2 = new Rectangle(20, 0, 20, 32);
        public static Rectangle MagicalBoomerangAnimationSourceRect3 = new Rectangle(0, 32, 20, 32);

        public static Vector2 MagicalBoomerangCollideSize = new Vector2(20, 32);
        public static Vector2 MagicalBoomerangCollideOrigin = new Vector2(10, 16);

    }
}
