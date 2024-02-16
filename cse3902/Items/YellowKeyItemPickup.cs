using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class YellowKeyItemPickUp : IItemPickup
{
    private Sprite YellowKeyItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public YellowKeyItemPickUp(GameContent content)
    {
        YellowKeyItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(240, 0, 8, 15) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        YellowKeyItem.SetPosition(itemPosition);

        YellowKeyItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}