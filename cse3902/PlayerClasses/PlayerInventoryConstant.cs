using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Items;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using cse3902;
using System.Reflection.Emit;
using cse3902.Enemy;
namespace cse3902.PlayerClasses
{
    public class PlayerInventoryConstant
    {
        // Health related constants
        public const int MaxLifeContainers = 5;
        public const int InitialHealth = 5;

        // HUD related constants
        public const int HudXOffset = 500;
        public const int HeartSpacing = 16;

        // Position offsets
        public const float HudHeartOriginX = 3.5f;
        public const float HudHeartOriginY = 3.5f;
        public const float SlotAPositionX = 440 + 18;
        public const float SlotBPositionX = 375 + 9;
        public const float SlotBPositionY = 60 + 9;
        public const float SelectBoxPositionX = 460;
        public const float SelectBoxPositionY = 170;

        // Scaling factors
        public const float BlackBackgroundScale = 10000000f;
        public const float InventoryScale = 3.5f;

        // Rectangle dimensions
        public const int InventoryWidth = 250;
        public const int InventoryHeight = 173;
        public const int BlackBackgroundWidth = 11;
        public const int BlackBackgroundHeight = 11;
        public const int SelectBoxWidth = 16;
        public const int SelectBoxHeight = 16;

        public const int MapPositionX = 160;
        public const int MapPositionY = 380;
        public const int CompassPositionX = 160;
        public const int CompassPositionY = 540;
        public const int SelectBoxBasePositionX = 460;
        public const int SelectBoxBasePositionY = 170;


        public static readonly Vector2 HudHeartOrigin = new Vector2(3.5f, 3.5f);

        public static readonly Rectangle Inventory = new Rectangle(1, 11, 250, 173);
        public static readonly Rectangle BlackBackground = new Rectangle(1, 11, 11, 11);
        public static readonly Rectangle MapSourceRect = new Rectangle(87, 0, 8, 15);
        public static readonly Rectangle SelectBoxSourceRect = new Rectangle(519, 137, 16, 16);
        public static readonly Vector2 blackoutPosition = new Vector2(0, 175 * 3.5f);

        public static readonly Rectangle fadeHeart = new Rectangle(627, 117, 8, 8);

        public static Vector2 InventoryPosition = new Vector2(0, -600);
        public static Vector2 NewInventoryPosition = new Vector2(0, -600);
        public static Vector2 itemcopt2offset = new Vector2(375 + 18, 194 * 3.5f + 18);
        public static Vector2 radaroffset = new Vector2(480, 380);
        public static Vector2 itemcopy = new Vector2(256, 196);
    }
}

