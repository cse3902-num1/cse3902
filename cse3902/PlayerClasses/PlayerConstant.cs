using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace cse3902.PlayerClasses
{
    public class PlayerConstant
    {
        public static Rectangle PlayerWalkingLeftAnimation1 = new Rectangle(0 * 16, 0 * 16, 16, 16);
        public static Rectangle PlayerWalkingLeftAnimation2 = new Rectangle(1 * 16, 0 * 16, 16, 16);
        public static Rectangle PlayerWalkingLeftAnimation3 = new Rectangle(2 * 16, 0 * 16, 16, 16);
        public static Rectangle PlayerWalkingLeftAnimation4 = new Rectangle(3 * 16, 0 * 16, 16, 16);
        public static Rectangle PlayerWalkingRightAnimation1 = new Rectangle(0 * 16, 1 * 16, 16, 16);
        public static Rectangle PlayerWalkingRightAnimation2 = new Rectangle(1 * 16, 1 * 16, 16, 16);
        public static Rectangle PlayerWalkingRightAnimation3 = new Rectangle(2 * 16, 1 * 16, 16, 16);
        public static Rectangle PlayerWalkingRightAnimation4 = new Rectangle(3 * 16, 1 * 16, 16, 16);
        public static Rectangle PlayerWalkingUpAnimation1 = new Rectangle(0 * 16, 2 * 16, 16, 16);
        public static Rectangle PlayerWalkingUpAnimation2 = new Rectangle(1 * 16, 2 * 16, 16, 16);
        public static Rectangle PlayerWalkingUpAnimation3 = new Rectangle(2 * 16, 2 * 16, 16, 16);
        public static Rectangle PlayerWalkingUpAnimation4 = new Rectangle(3 * 16, 2 * 16, 16, 16);

        public static Rectangle PlayerWalkingDownAnimation1 = new Rectangle(0 * 16, 3 * 16, 16, 16);
        public static Rectangle PlayerWalkingDownAnimation2 = new Rectangle(1 * 16, 3 * 16, 16, 16);
        public static Rectangle PlayerWalkingDownAnimation3 = new Rectangle(2 * 16, 3 * 16, 16, 16);
        public static Rectangle PlayerWalkingDownAnimation4 = new Rectangle(3 * 16, 3 * 16, 16, 16);

        public static Vector2 KeysTextPosition = new Vector2(280, 70);
        public static Vector2 BombsPosition = new Vector2(280, 70);
        public static Vector2 RubiesTextPosition = new Vector2(280, 70);
        public static Rectangle HudHeartPosition = new Rectangle(645, 117, 8, 8);
        public static Rectangle HudFadedHeartPosition = new Rectangle(627, 117, 8, 8);

        public static Rectangle HudSwordPositionnew = new Rectangle(104, 0, 8, 16);
        public static Rectangle PlayerAttackingLeftAnimation1 = new Rectangle(0 * 27, 0 * 28, 27, 28);
        public static Rectangle PlayerAttackingLeftAnimation2 = new Rectangle(1 * 27, 0 * 28, 27, 28);
        public static Rectangle PlayerAttackingLeftAnimation3 = new Rectangle(2 * 27, 0 * 28, 27, 28);
        public static Rectangle PlayerAttackingLeftAnimation4 = new Rectangle(3 * 27, 0 * 28, 27, 28);
        public static Rectangle PlayerAttackingRightAnimation1 = new Rectangle(0 * 27, 1 * 28, 27, 28);
        public static Rectangle PlayerAttackingRightAnimation2 = new Rectangle(1 * 27, 1 * 28, 27, 28);
        public static Rectangle PlayerAttackingRightAnimation3 = new Rectangle(2 * 27, 1 * 28, 27, 28);
        public static Rectangle PlayerAttackingRightAnimation4 = new Rectangle(3 * 27, 1 * 28, 27, 28);
        public static Rectangle PlayerAttackingUpAnimation1 = new Rectangle(0 * 27, 2 * 28, 27, 28);
        public static Rectangle PlayerAttackingUpAnimation2 = new Rectangle(1 * 27, 2 * 28, 27, 28);
        public static Rectangle PlayerAttackingUpAnimation3 = new Rectangle(2 * 27, 2 * 28, 27, 28);
        public static Rectangle PlayerAttackingUpAnimation4 = new Rectangle(3 * 27, 2 * 28, 27, 28);
        public static Rectangle PlayerAttackingDownAnimation1 = new Rectangle(0 * 27, 3 * 28, 27, 28);
        public static Rectangle PlayerAttackingDownAnimation2 = new Rectangle(1 * 27, 3 * 28, 27, 28);
        public static Rectangle PlayerAttackingDownAnimation3 = new Rectangle(2 * 27, 3 * 28, 27, 28);
        public static Rectangle PlayerAttackingDownAnimation4 = new Rectangle(3 * 27, 3 * 28, 27, 28);

        public static Rectangle PlayerIdleLeft = new Rectangle(0 * 16, 0 * 16, 16, 16);
        public static Rectangle PlayerIdleRight = new Rectangle(0 * 16, 1 * 16, 16, 16);
        public static Rectangle PlayerIdleUp = new Rectangle(0 * 16, 2 * 16, 16, 16);
        public static Rectangle PlayerIdleDown = new Rectangle(0 * 16, 3 * 16, 16, 16);

        public static Rectangle PlayerUseItemLeft = new Rectangle(0 * 16, 0 * 16, 16, 16);
        public static Rectangle PlayerUseItemRight = new Rectangle(0 * 16, 1 * 16, 16, 16);
        public static Rectangle PlayerUseItemUp = new Rectangle(0 * 16, 2 * 16, 16, 16);
        public static Rectangle PlayerUseItemDown = new Rectangle(0 * 16, 3 * 16, 16, 16);



    }
}
