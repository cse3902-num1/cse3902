using Microsoft.Xna.Framework;

namespace cse3902;

public class IntAnimator
{
    private int _min = 0;
    private int _max = 1;
    private float _duration = 1.0f; /* in seconds */

    public IntAnimator(int min, int max, float duration)
    {
        _min = min;
        _max = max;
        _duration = duration;
    }

    public void Update(ref int data, GameTime gameTime)
    {
        double t = (gameTime.TotalGameTime.TotalSeconds % _duration) / _duration;

        /* "lerp" between min and max according to t */
        data = _min + (int)((float)(_max - _min + 1) * (float) t);
    }
}
