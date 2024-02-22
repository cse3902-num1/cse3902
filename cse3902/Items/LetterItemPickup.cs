using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class LetterItemPickup : IItemPickup
{
    private Sprite LetterSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public LetterItemPickup(GameContent content)
    {
        LetterSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(87, 16, 8, 15) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        LetterSprite.SetPosition(itemPosition);

        LetterSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}