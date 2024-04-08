using System.Diagnostics;
using cse3902.RoomClasses;

namespace cse3902;

public static class EventBus
{
    public delegate void _PlayerDying(IPlayer player);
    public static _PlayerDying PlayerDying = (IPlayer player) => {};
    
    // delegates need types, and have to be public if an instance of them is public
    // even though we don't intend anyone else to use the type itself :(
    public delegate void _LoggingMessage(string msg);
    public static _LoggingMessage LoggingMessage = (string msg) => {}; // must have a value, so set it to a lambda function that does nothing

    /* when the player enters a door. direction determines which door was entered */
    public delegate void _EnteringDoor(Direction direction);
    public static _EnteringDoor EnteringDoor = (Direction direction) => { Debug.WriteLine("[event] EnteringDoor " + direction); }; 

    /* when the "current room" changes. room is the new room */
    public delegate void _RoomChanging(Room room);
    public static _RoomChanging RoomChanging = (Room room) => {};
}