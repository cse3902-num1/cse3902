using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class NonMovingNonAnimatedSprite : ISprite
{
    private bool _isVisible = true;

    private Texture2D _texture;
    private Vector2 _position;
    private Vector2 _scale = Vector2.One * 4;
    private Rectangle _srcRect = new Rectangle(1, 11, 15, 15);

    public NonMovingNonAnimatedSprite(Vector2 position)
    {
        _position = position;
    }

    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("spritesheet_link");
    }

    public void Update(Game game, GameTime gameTime, List<InputState> inputStates)
    {
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowNonMovingNonAnimatedSprite)) _isVisible = true;
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowNonMovingAnimatedSprite))    _isVisible = false;
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowMovingNonAnimatedSprite))    _isVisible = false;
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowMovingAnimatedSprite))       _isVisible = false;
    }

    public void Draw(Game game, GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!_isVisible)
        {
            return;
        }

        Vector2 size = _srcRect.Size.ToVector2() * _scale;
        Vector2 centerOffset = size / 2;
        Rectangle dstRect = new Rectangle(
            _position.ToPoint() - centerOffset.ToPoint(),
            size.ToPoint()
        );

        spriteBatch.Draw(_texture, dstRect, _srcRect, Color.White);
    }
}
