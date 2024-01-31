using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cse3902;

public class MouseController : IController
{
    private InputState _inputState;

    private GameWindow _window;

    public MouseController(GameWindow window)
    {
        _inputState = new InputState();
        _window = window;
    }

    public InputState GetState()
    {
        return _inputState;
    }

    public void Update(GameTime gameTime)
    {
        _inputState.Update();

        MouseState state = Mouse.GetState();

        _inputState.SetPressed(InputAction.Quit, state.RightButton == ButtonState.Pressed);

        if (state.LeftButton == ButtonState.Pressed)
        {
            int x = state.X;
            int y = state.Y;
            int cx = _window.ClientBounds.Width / 2;
            int cy = _window.ClientBounds.Height / 2;
            _inputState.SetPressed(InputAction.ShowNonMovingNonAnimatedSprite,         x < cx && y < cy); // top left
            _inputState.SetPressed(InputAction.ShowNonMovingAnimatedSprite, x >= cx && y < cy); // top right
            _inputState.SetPressed(InputAction.ShowMovingNonAnimatedSprite,               x < cx && y >= cy); // bottom left
            _inputState.SetPressed(InputAction.ShowMovingAnimatedSprite,       x >= cx && y >= cy); // bottom right
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