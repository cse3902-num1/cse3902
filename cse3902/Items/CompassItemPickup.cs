using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class CompassItemPickUp : IItemPickup
{
    private Sprite CompassItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public CompassItemPickUp(GameContent content)
    {
        CompassItem = new Sprite(content.ItemSheet, new List<Rectangle>() {
                        new Rectangle(257, 1, 12, 13) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        CompassItem.SetPosition(itemPosition);

        CompassItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}