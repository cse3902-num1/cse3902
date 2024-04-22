using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Enemy
{
    public class EnermyConstant
    {
        public const int DRAGON_HEALTH = 40;
        public const int GEL_HEALTH = 4;
        public const int GORIYA_HEALTH = 12;
        public const int KEESE_HEALTH = 4;
        public const int SKELETON_HEALTH = 4;
        public const int OLD_MAN_HEALTH = 40;

        public static Vector2 moveRightOneUnit = new Vector2(1, 0);
        public static Vector2 moveUpOneUnit = new Vector2(0, -1);
        public static Vector2 moveDownOneUnit = new Vector2(0, 1);
        public static Rectangle DragonSpriteSheetAnimation1 = new Rectangle(1, 11, 25, 32);
        public static Rectangle DragonSpriteSheetAnimation2 = new Rectangle(26, 11, 25, 32);
        public static Rectangle DragonSpriteSheetAnimation3 = new Rectangle(51, 11, 25, 32);
        public static Rectangle DragonSpriteSheetAnimation4 = new Rectangle(76, 11, 25, 32);
        public static Vector2 DragonOrigin = new Vector2(12.5f, 16f);
        public static Vector2 DragonPosition = new Vector2(500, 200);
        public static Vector2 DragonColliderSize = new Vector2(25 * 2, 32 * 2);
        public static Vector2 DragonColliderOrigin = new Vector2(12.5f * 2, 16f * 2);
        public static Vector2 DragonFireBallVelocity1 = new Vector2(-200f, -50f);
        public static Vector2 DragonFireBallVelocity2 = new Vector2(-200f, 0f);
        public static Vector2 DragonFireBallVelocity3 = new Vector2(-200f, 50f);
        public static Rectangle GelSpriteSheetAnimation1 = new Rectangle(1, 11, 7, 16);
        public static Rectangle GelSpriteSheetAnimation2 = new Rectangle(10, 11, 7, 16);
        public static Vector2 GelOrigin = new Vector2(3.5f, 8f);
        public static Vector2 GelInitialPosition = new Vector2(200, 200);
        public static Vector2 GelColliderSize = new Vector2(7 * 2, 16 * 2);
        public static Vector2 GelColliderOrigin = new Vector2(3.5f * 2, 8f * 2);
        public static Rectangle GoriyaSpriteSheetUp1 = new Rectangle(0, 32, 16, 16);
        public static Rectangle GoriyaSpriteSheetUp2 = new Rectangle(16, 32, 16, 16);
        public static Rectangle GoriyaSpriteSheetDown1 = new Rectangle(0, 48, 16, 16);
        public static Rectangle GoriyaSpriteSheetDown2 = new Rectangle(16, 48, 16, 16);
        public static Rectangle GoriyaSpriteSheetRight1 = new Rectangle(0, 16, 16, 16);
        public static Rectangle GoriyaSpriteSheetRight2 = new Rectangle(16, 16, 16, 16);
        public static Rectangle GoriyaSpriteSheetLeft1 = new Rectangle(0, 0, 16, 16);
        public static Rectangle GoriyaSpriteSheetLeft2 = new Rectangle(16, 0, 16, 16);
        public static Vector2 GoriyaOrigin = new Vector2(8, 8);
        public static Vector2 GoriyaInitialPosition = new Vector2(400, 200);
        public static Vector2 GoriyaColliderSize = new Vector2(16 * 2, 16 * 2);
        public static Vector2 GoriyaColliderOrigin = new Vector2(8 * 2, 8 * 2);
        public static Rectangle KeeseSpriteSheet1 = new Rectangle(184, 11, 15, 16);
        public static Rectangle KeeseSpriteSheet2 = new Rectangle(200, 11, 15, 16);
        public static Vector2 KeeseOrigin = new Vector2(7.5f, 8f);
        public static Vector2 KeeseInitialPosition = new Vector2(200, 200);
        public static Vector2 KeeseColliderSize = new Vector2(15 * 3, 16 * 3);
        public static Vector2 KeeseColliderOrigin = new Vector2(7.5f * 3, 8f * 3);
        public static Rectangle SkeletonSpriteSheet1 = new Rectangle(0, 0, 15, 15);
        public static Rectangle SkeletonSpriteSheet2 = new Rectangle(15, 0, 15, 15);
        public static Vector2 SkeletonOrigin = new Vector2(7.5f, 7.5f);
        public static Vector2 SkeletonInitialPosition = new Vector2(200, 200);
        public static Vector2 SkeletonColliderSize = new Vector2(15 * 2, 15 * 2);
        public static Vector2 SkeletonColliderOrigin = new Vector2(7.5f * 2, 7.5f * 2);
        public static Rectangle OldMan = new Rectangle(0, 0, 15, 15);
        public static Vector2 OldManOrigin = new Vector2(7.5f, 7.5f);
        public static Vector2 OldManPosition = new Vector2(500, 300);
        public static Vector2 OldmanColliderSize = new Vector2(15 * 2, 15 * 2);
        public static Vector2 OldmanColliderOrigin = new Vector2(7.5f * 2, 7.5f * 2);
        public static Vector2 OldmanFireBallVelocity1 = new Vector2(-200f, -200f);
        public static Vector2 OldmanFireBallVelocity2 = new Vector2(-200f, 0f);
        public static Vector2 OldmanFireBallVelocity3 = new Vector2(-200f, 200f);
        public static Vector2 OldmanFireBallVelocity4 = new Vector2(200f, 200f);
        public static Vector2 OldmanFireBallVelocity5 = new Vector2(200f, 0f);
        public static Vector2 OldmanFireBallVelocity6 = new Vector2(0f, 200f);
        public static Vector2 OldmanFireBallVelocity7 = new Vector2(0f, -200f);
        public static Vector2 OldmanFireBallVelocity8 = new Vector2(200f, -200f);
       

    }
}
