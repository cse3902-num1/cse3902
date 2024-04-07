using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class Constant
    {

        public static Vector2 textPosMidScreen;
        public static int TextPosMidScreenX = 868 / 2 - 50;
        public static int TextPosMidScreenY = 828 /2 - 50;
        public static int RectangleWidth = 16;
        public static int RectangleHeight = 16;
        public static int BlockOriginX = 8;
        public static int BlockOriginY = 8;
        public static int BoxColliderOriginX = 8;
        public static int BoxColliderOriginY = 8;
        public static int DoorWidth = 32;
        public static int DoorHeight = 32;
        public static float DoorScale = 3.0f;
        public static Vector2 TopDoorPosition = new Vector2(336, 0);
        public static Vector2 BottomDoorPosition = new Vector2(336, 432);
        public static Vector2 LeftDoorPosition = new Vector2(0, 216);
        public static Vector2 RightDoorPosition = new Vector2(672, 216);
        public static Vector2 GeneralPosition = new Vector2(50, 300);
        public static Vector2 moveLeftOneUnit = new Vector2(-1, 0);
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



    }
}
