using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private List<IController> _controllers;

    private List<ISprite> _sprites;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _controllers = new List<IController> {
            //new KeyboardController(),
            new MouseController(Window)
        };
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _sprites = new List<ISprite> {
            new NonMovingNonAnimatedSprite(GetScreenCenter()),
            new NonMovingAnimatedSprite(   GetScreenCenter()),
            new MovingNonAnimatedSprite(   GetScreenCenter()),
            new MovingAnimatedSprite(      GetScreenCenter()),
            new TextSprite(Vector2.One * 10),
        };

        foreach (ISprite sprite in _sprites)
        {
            sprite.LoadContent(Content);
        }
    }

    private Vector2 GetScreenCenter()
    {
        return new Vector2(
            Window.ClientBounds.Width / 2,
            Window.ClientBounds.Height / 2
        );
    }

    protected override void Update(GameTime gameTime)
    {

        foreach (IController controller in _controllers)
        {
            controller.Update(gameTime);
        }

        /* collect input states */
        List<InputState> inputStates = new List<InputState>();
        foreach (IController controller in _controllers)
        {
            inputStates.Add(controller.GetState());
        }

        if (InputState.IsAnyPressed(inputStates, InputAction.Quit))
        {
            Exit();
        }

        foreach (ISprite sprite in _sprites)
        {
            sprite.Update(this, gameTime, inputStates);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Lavender);

        /* enable nearest-neighbor texture filtering */
        SamplerState s = new SamplerState();
        s.Filter = TextureFilter.Point;

        _spriteBatch.Begin(samplerState: s);

        foreach (ISprite sprite in _sprites)
        {
            sprite.Draw(this, gameTime, _spriteBatch);
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
