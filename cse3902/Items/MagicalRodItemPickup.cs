using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class MagicalRodItemPickup : IItemPickup
{
    private Sprite MagicalRodSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public MagicalRodItemPickup(GameContent content)
    {
        MagicalRodSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(225, 0, 6, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        MagicalRodSprite.SetPosition(itemPosition);

        MagicalRodSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}