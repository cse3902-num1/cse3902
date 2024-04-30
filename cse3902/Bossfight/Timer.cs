using Microsoft.Xna.Framework;

namespace cse3902.Bossfight;

public class Timer {
    public double Time = 0;
    public bool IsStarted = false;

    public void Start(double initial = 0) {
        Time = initial;
        IsStarted = true;
    }

    public void Stop() {
        IsStarted = false;
    }

    public void Update(GameTime gameTime) {
        if (!IsStarted) return;
        Time += gameTime.ElapsedGameTime.TotalSeconds;
    }
}