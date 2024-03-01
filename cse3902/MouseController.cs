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
    }
}
