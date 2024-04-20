using cse3902.Projectiles;
using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace cse3902;

public class GreenBoomerangInventoryItem : IInventoryItem
{
    private GameContent content;
    private float directionShift = 200f;
    public GreenBoomerangInventoryItem(GameContent content)
    {
        this.content = content;
    }

    public void Use(IPlayer player, Room room)
    {
        Vector2 direction = player.Facing.asVector2();
        GreenBoomerang greenBoomerangProjectile = new GreenBoomerang(content, room, player.Position, direction * directionShift);
        SoundManager.Manager.arrowBoomerangSound();
        room.Projectiles.Add(greenBoomerangProjectile);
        greenBoomerangProjectile.isEnermyProjectile = false;
    }
}