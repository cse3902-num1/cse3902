using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class PurpleTriangleItemPickUp : IItemPickup
{
    private Sprite PurpleTriangleItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public PurpleTriangleItemPickUp(GameContent content)
    {
        PurpleTriangleItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(274, 18, 11, 12) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        PurpleTriangleItem.SetPosition(itemPosition);

        PurpleTriangleItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}