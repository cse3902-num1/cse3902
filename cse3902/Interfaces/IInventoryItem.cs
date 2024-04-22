using cse3902.RoomClasses;

namespace cse3902;

public interface IInventoryItem
{
    public void Use(IPlayer player, Level level);
}
