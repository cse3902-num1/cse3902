using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class YellowDragonItemPickUp : IItemPickup
{
    private Sprite YellowDragonItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public YellowDragonItemPickUp(GameContent content)
    {
        YellowDragonItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(87, 0, 8, 15) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        YellowDragonItem.SetPosition(itemPosition);

        YellowDragonItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}