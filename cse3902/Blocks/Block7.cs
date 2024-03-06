using System.Collections.Generic;
using cse3902.Objects;
using Microsoft.Xna.Framework;

namespace cse3902;

public class Block7 : BasicBlock
{
    public Block7(GameContent content)
    {
        sprite = new Sprite(
            content.TilesSheet,
            new List<Rectangle>() {
                new Rectangle(53, 28, 16, 16)
            },
            new Vector2(8, 8)
        );
        collider = new BoxCollider(Position, Size, ColliderType);
    }
}