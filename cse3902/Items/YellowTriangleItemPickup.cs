using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace cse3902;

public class YellowTriangleItemPickUp : IItemPickup
{
    private Sprite YellowTriangleItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public YellowTriangleItemPickUp(GameContent content)
    {
        YellowTriangleItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(274, 3, 11, 12) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        YellowTriangleItem.SetPosition(itemPosition);

        YellowTriangleItem.Draw(spriteBatch);
    }
    
    public void Update(GameTime gameTime)
    {
    }


}