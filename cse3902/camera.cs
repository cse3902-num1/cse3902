using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class Camera
{
    public SpriteBatch spriteBatch;
    private SamplerState samplerState;
    private Vector2 size;

    public Vector2 Position {set;get;}

    public Camera(SpriteBatch spriteBatch, Vector2 size) {
        this.spriteBatch = spriteBatch;
        samplerState = new SamplerState();
        samplerState.Filter = TextureFilter.Point;
        this.size = size;
        Position = new Vector2(0, 0);
    }

    public void BeginDraw()
    {
        Matrix transform = Matrix.CreateTranslation(new Vector3(
            -Position.X + size.X/2,
            -Position.Y + size.Y/2,
            0
        ));

        spriteBatch.Begin(
            samplerState: this.samplerState,
            transformMatrix: transform
        );
    }

    public void EndDraw()
    {
        spriteBatch.End();
    }
}