using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class YellowBoomerangItemPickup : IItemPickup
{
    private Sprite YellowBoomerangItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public YellowBoomerangItemPickup(GameContent content)
    {
        YellowBoomerangItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(128, 2, 5, 9) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        YellowBoomerangItem.SetPosition(itemPosition);

        YellowBoomerangItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }
}
