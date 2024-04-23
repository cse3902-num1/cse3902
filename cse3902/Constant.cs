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
        public static Vector2 moveLeftOneUnit = new Vector2(-1, 0);
        public static Vector2 moveRightOneUnit = new Vector2(1, 0);
        public static Vector2 moveUpOneUnit = new Vector2(0, -1);
        public static Vector2 moveDownOneUnit = new Vector2(0, 1);
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
        public static Vector2 DoorColliderScaleFactor = new Vector2(16, 16) * 3;
        public static Vector2 DoorColliderSize = new Vector2(32, 32) * 3;
        public static Vector2 DoorColliderOrigin = new Vector2(16, 16) * 3;

        public static Rectangle HudSprite = new Rectangle(256, 11, 256, 56);
        public static Vector2 HudOrigin = new Vector2(8, 8);
        public static float HudScaleFactor = 3.0f;

        public static readonly Vector2 TextOrigin = new Vector2(45, 10);

        public static readonly Vector2 WinGameTextOrigin = new Vector2(55, 10);
        public static readonly Vector2 StartOverTextOrigin = new Vector2(105, -20);
        
    }
}
