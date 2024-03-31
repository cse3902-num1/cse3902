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
        }

        public void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }

        public bool isLeftClick()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        public bool isRightClick()
        {
            return currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released;
        }

        public bool isPlayerMoveLeftPressed() { return false; }
        public bool isPlayerMoveRightPressed() { return false; }
        public bool isPlayerMoveUpPressed() { return false; }
        public bool isPlayerMoveDownPressed() { return false; }
        public bool isPlayerAttackJustPressed() { return false; }
        public bool isPlayerTakeDamageJustPressed() { return false; }
        public bool isPlayerUseItem1JustPressed() { return false; }
        public bool isPlayerUseItem2JustPressed() { return false; }
        public bool isPlayerUseItem3JustPressed() { return false; }
        public bool isPlayerUseItem4JustPressed() { return false; }
        public bool isPlayerUseItem5JustPressed() { return false; }
        public bool isPlayerUseItem6JustPressed() { return false; }
        public bool isPlayerUseItem7JustPressed() { return false; }
        public bool isPlayerUseItem8JustPressed() { return false; }
        public bool isPlayerUseItem9JustPressed() { return false; }
        public bool isEnemyPressO() { return false; }
        public bool isEnemyPressP() { return false; }
        public bool isPreviousItemKeyPress() { return false; }
        public bool isNextItemKeyPress() { return false; }
        public bool isNextBlockPressed() { return false; }
        public bool isPreviousBlockPressed() { return false; }
        public bool isResetPressed() { return false; }
        public bool isQuitPressed() { return false; }
    }
}
