using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class FairyTailItemPickUp : IItemPickup
{
    private Sprite FairyTailItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public FairyTailItemPickUp(GameContent content)
    {
        FairyTailItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(39, 0, 7, 15) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        FairyTailItem.SetPosition(itemPosition);

        FairyTailItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}