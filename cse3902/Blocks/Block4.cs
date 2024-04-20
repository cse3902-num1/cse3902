using System.Collections.Generic;
using cse3902.Objects;
using Microsoft.Xna.Framework;

namespace cse3902;

public class Block4 : BasicBlock
{
    private int spriteSheetXPosition = 53;
    private int spriteSheetYPosition = 11;
    public Block4(GameContent content)
    {
        sprite = new Sprite(
            content.TilesSheet,
            new List<Rectangle>() {
                new Rectangle(spriteSheetXPosition, spriteSheetYPosition, Constant.RectangleWidth, Constant.RectangleHeight)
            },
            new Vector2(Constant.BlockOriginX, Constant.BlockOriginX) // width and height both multiple by 8
        );
        collider = new BoxCollider(Position, Size, new Vector2(Constant.BoxColliderOriginX, Constant.BoxColliderOriginY), ColliderType.BLOCK);
    }
}