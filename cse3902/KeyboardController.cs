using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cse3902;

public class KeyboardController : IController
{
    private InputState _inputState;

    public KeyboardController()
    {
        _inputState = new InputState();
    }

    public InputState GetState()
    {
        return _inputState;
    }

    public void Update(GameTime gameTime)
    {
        _inputState.Update();

        KeyboardState keyboardState = Keyboard.GetState();
        _inputState.SetPressed(InputAction.Quit,                     keyboardState.IsKeyDown(Keys.D0));
        _inputState.SetPressed(InputAction.ShowNonMovingNonAnimatedSprite,         keyboardState.IsKeyDown(Keys.D1));
        _inputState.SetPressed(InputAction.ShowNonMovingAnimatedSprite, keyboardState.IsKeyDown(Keys.D2));
        _inputState.SetPressed(InputAction.ShowMovingNonAnimatedSprite,               keyboardState.IsKeyDown(Keys.D3));
        _inputState.SetPressed(InputAction.ShowMovingAnimatedSprite,       keyboardState.IsKeyDown(Keys.D4));
    }
}
