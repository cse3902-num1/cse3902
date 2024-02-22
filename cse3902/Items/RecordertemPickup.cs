using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class RecorderItemPickup : IItemPickup
{
    private Sprite RecorderSprite;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public RecorderItemPickup(GameContent content)
    {
        RecorderSprite = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(187, 0, 5, 17) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        RecorderSprite.SetPosition(itemPosition);

        RecorderSprite.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}