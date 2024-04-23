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

    public delegate void _HitStop(int duration_ms);
    public static _HitStop HitStop = (int duration_ms) => {};
    
    public delegate void _CameraShake(int duration_ms, float intensity);
    public static _CameraShake CameraShake = (int duration_ms, float intensity) => {};
}