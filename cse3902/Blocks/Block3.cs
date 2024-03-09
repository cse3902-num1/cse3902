using System.Collections.Generic;
using cse3902.Objects;
using Microsoft.Xna.Framework;

namespace cse3902;

public class Block3 : BasicBlock
{
    public Block3(GameContent content)
    {
        sprite = new Sprite(
            content.TilesSheet,
            new List<Rectangle>() {
                new Rectangle(36, 11, 16, 16)
            },
            new Vector2(8, 8)
        );
        collider = new BoxCollider(Position, Size, new Vector2(8, 8), ColliderType.BLOCK);
    }
}