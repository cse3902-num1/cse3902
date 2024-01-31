using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class NonMovingAnimatedSprite : ISprite
{
    private bool _isVisible = false;

    private Vector2 _position;
    private Vector2 _scale = Vector2.One * 4;

    private Texture2D _spriteSheet;
    private List<Rectangle> _srcRects = new List<Rectangle>();
    private int _frame = 0;
    private IntAnimator _frameAnimator;

    public NonMovingAnimatedSprite(Vector2 position)
    {
        _position = position;
    }

    public void LoadContent(ContentManager content)
    {
        _spriteSheet = content.Load<Texture2D>("spritesheet_link");
        _srcRects = new List<Rectangle> {
            new(1, 11, 15, 15),
            new(18, 11, 15, 15),
            new(35, 11, 15, 15),
            new(52, 11, 15, 15),
            new(69, 11, 15, 15),
            new(86, 11, 15, 15),
        };
        _frameAnimator = new IntAnimator(0, _srcRects.Count - 1, 1.0f);
    }

    public void Update(Game game, GameTime gameTime, List<InputState> inputStates)
    {
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowNonMovingNonAnimatedSprite)) _isVisible = false;
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowNonMovingAnimatedSprite))    _isVisible = true;
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowMovingNonAnimatedSprite))    _isVisible = false;
        if (InputState.IsAnyJustPressed(inputStates, InputAction.ShowMovingAnimatedSprite))       _isVisible = false;
    }

    public void Draw(Game game, GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!_isVisible)
        {
            return;
        }

        _frameAnimator.Update(ref _frame, gameTime);

        Vector2 size = _srcRects[_frame].Size.ToVector2() * _scale;
        Vector2 centerOffset = size / 2;
        Rectangle dstRect = new Rectangle(
            _position.ToPoint() - centerOffset.ToPoint(),
            size.ToPoint()
        );

        spriteBatch.Draw(_spriteSheet, dstRect, _srcRects[_frame], Color.White);
    }
}
