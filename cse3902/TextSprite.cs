using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class TextSprite : ISprite
{
    private string _text = @"credits
sprites from https://www.spriters-resource.com/nes/legendofzelda/sheet/8366/";
    private SpriteFont _font;
    private Color _color = Color.Black;
    private Vector2 _position;

    public TextSprite(Vector2 position)
    {
        _position = position;
    }

    public void LoadContent(ContentManager content)
    {
        _font = content.Load<SpriteFont>("font_arial");
    }

    public void Update(Game game, GameTime gameTime, List<InputState> inputStates)
    {
        // do nothing!
    }

    public void Draw(Game game, GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(_font, _text, _position, _color);
    }
}
