using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace cse3902;

public enum InputAction
{
    Quit = 0,
    ShowNonMovingNonAnimatedSprite = 1,
    ShowNonMovingAnimatedSprite = 2,
    ShowMovingNonAnimatedSprite = 3,
    ShowMovingAnimatedSprite = 4,
}

/* public state of an IController */
public class InputState
{
    /* Stores the states of each action.
     * Always contains, as keys, all the values in the InputActions enum. */
    private Dictionary<InputAction, bool> _actionsIsPressed = new Dictionary<InputAction, bool>();
    private Dictionary<InputAction, bool> _actionsWasPressed = new Dictionary<InputAction, bool>();

    public InputState()
    {
        /* fill Actions dictionary with values from InputActions enum */
        foreach (InputAction action in System.Enum.GetValues<InputAction>())
        {
            _actionsIsPressed.Add(action, false);
            _actionsWasPressed.Add(action, false);
        }
    }

    /* call during the current frame before updating the actions' states
     * (e.g. calling SetPressed() ) */
    public void Update()
    {
        foreach (InputAction action in _actionsIsPressed.Keys)
        {
            _actionsWasPressed[action] = _actionsIsPressed[action];
            _actionsIsPressed[action] = false;
        }
    }

    public void SetPressed(InputAction action, bool isPressed)
    {
        _actionsIsPressed[action] = isPressed;
    }

    public bool IsPressed(InputAction action)
    {
        return _actionsIsPressed[action];
    }

    public bool IsJustPressed(InputAction action)
    {
        return !_actionsWasPressed[action] && _actionsIsPressed[action];
    }

    /* returns true if the action is pressed in any InputState */
    public static bool IsAnyPressed(IEnumerable<InputState> inputStates, InputAction action)
    {
        foreach (InputState state in inputStates)
        {
            if (state._actionsIsPressed[action])
            {
                return true;
            }
        }
        return false;
    }

    /* returns true if the action was just pressed in any InputState,
     * (and wasn't held down in any other InputStates) */
    public static bool IsAnyJustPressed(IEnumerable<InputState> inputStates, InputAction action)
    {
        foreach (InputState state in inputStates)
        {
            if (state._actionsWasPressed[action])
            {
                return false;
            }
        }
        foreach (InputState state in inputStates)
        {
            if (state._actionsIsPressed[action])
            {
                return true;
            }
        }
        return false;
    }
}

public interface IController
{
    public InputState GetState();
    public void Update(GameTime gameTime);
}
