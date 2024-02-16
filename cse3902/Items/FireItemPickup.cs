using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902;

public class FireItemPickUp : IItemPickup
{
 
    private List<Sprite> FireItems;
    private Vector2 itemPosition = new Vector2(300, 200); // Example positions

    public FireItemPickUp(GameContent content)
    {
        FireItems = new List<Sprite>(){
            new Sprite(content.SpriteSheetLinkAdditionItems, new List<Rectangle>() {
                        new Rectangle(191, 185, 16, 16) }),
            new Sprite(content.SpriteSheetFlipped, new List<Rectangle>() {
                        new Rectangle(164, 185, 16, 16) }),
        };
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Sprite f in FireItems) {
            f.SetPosition(itemPosition);
            f.Draw(spriteBatch);
        }
        
    }

    public void Update(GameTime gameTime)
    {

        foreach (Sprite f in FireItems)
        {
            f.Update(gameTime);
        }

    }
}