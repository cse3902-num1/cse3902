using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class FireItemPickUp : IItemPickup
{
    private Sprite FireItem;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public FireItemPickUp(GameContent content)
    {
        FireItem = new Sprite(content.SpriteSheetLinkAdditionItems, new List<Rectangle>() {
                        new Rectangle(191, 185, 16, 16) });
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        FireItem.SetPosition(itemPosition);

        FireItem.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
    }


}