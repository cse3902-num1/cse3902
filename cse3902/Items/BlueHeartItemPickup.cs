using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class BlueHeartItemPickUp : IItemPickup
{
    private Sprite BlueHeartItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public BlueHeartItemPickUp(GameContent content)
    {
        BlueHeartItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(0, 8, 7, 7) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        BlueHeartItem.SetPosition(itemPosition);

        BlueHeartItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}