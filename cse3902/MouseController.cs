using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cse3902;

public class MouseController : IController
{
    private GameWindow _window;

    public MouseController(GameWindow window)
    {
       
        _window = window;
    }

    public void Update(GameTime gameTime)
    {
       
        MouseState state = Mouse.GetState();


        if (state.LeftButton == ButtonState.Pressed)
        {
            int x = state.X;
            int y = state.Y;
            int cx = _window.ClientBounds.Width / 2;
            int cy = _window.ClientBounds.Height / 2;
           
        }
        // else
        // {
        //     _inputState.SetPressed(InputActions.ShowStaticSprite,         false); // top left
        //     _inputState.SetPressed(InputActions.ShowStaticAnimatedSprite, false); // top right
        //     _inputState.SetPressed(InputActions.ShowSprite,               false); // bottom left
        //     _inputState.SetPressed(InputActions.ShowAnimatedSprite,       false); // bottom right
        // }
    }
}