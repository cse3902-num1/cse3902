using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class MouseController : IController
    {
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        public MouseController()
        {
            currentMouseState = Mouse.GetState();
            previousMouseState = currentMouseState;
            Mouse.SetCursor(MouseCursor.Hand);
        }

        public void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);
        }

        public bool isLeftClick()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        public bool isRightClick()
        {
            return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
        }
        public Point GetMousePosition()
        {
            return new Point(currentMouseState.X, currentMouseState.Y);
        }

        public bool isPlayerMoveLeftPressed() { return false; }
        public bool isPlayerMoveRightPressed() { return false; }
        public bool isPlayerMoveUpPressed() { return false; }
        public bool isPlayerMoveDownPressed() { return false; }
        public bool isPlayerAttackJustPressed() { return false; }
        public bool isPlayerTakeDamageJustPressed() { return false; }
        public bool isPlayerUseBombJustPressed() { return false; }
        public bool isPlayerUseMagicalBoomerangPressed() { return false; }
        public bool isPlayerUseBlueBowPressed() { return false; }
        public bool isPlayerUseFireballPressed() { return false; }
        public bool isPlayerUseFirePressed() { return false; }
        public bool isPlayerUseGreenBoomerangPressed() { return false; }
        public bool isPlayerUseGreenBowPressed() { return false; }
        public bool isPlayerUsePurpleCrystalPressed() { return false; }
        public bool isEnemyPressO() { return false; }
        public bool isEnemyPressP() { return false; }
        public bool isPreviousItemKeyPress() { return false; }
        public bool isNextItemKeyPress() { return false; }
        public bool isNextBlockPressed() { return false; }
        public bool isPreviousBlockPressed() { return false; }
        public bool isResetPressed() { return false; }
        public bool isQuitPressed() { return false; }
        public bool isMutePressed() { return false; }
        public bool isExitPressed() { return false; }

        public bool isPausePressed() {return false;}
        public bool isInventoryDisplayedPressed() { return false; }
        public bool isSwitchSlotAPressed() { return false; }
        public bool isSwitchSlotBPressed() { return false; }
    }
}
