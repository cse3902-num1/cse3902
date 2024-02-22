using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class BookOfMagicItemPickup : IItemPickup
{
    private Sprite BookOfMagicSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public BookOfMagicItemPickup(GameContent content)
    {
        BookOfMagicSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(230, 0, 11, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        BookOfMagicSprite.SetPosition(itemPosition);

        BookOfMagicSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}