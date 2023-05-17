using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public abstract class Entity
{
    protected Texture2D Texture;
    protected Vector2 Position;
    protected float Velocity;
    protected float Rotation;
    
    public bool isExists = true;
    protected Vector2 Size => new(Texture.Width, Texture.Height);

    public abstract void Update(GameTime gameTime);
    public virtual void Draw()
    {
        Configurations.SpriteBatch.Draw(Texture, Position, null, Configurations.BaseColor, Rotation, Size/2,1, 0, 0);
    }

    public Vector2 GetPositionEntity()
    {
        return Position;
    }
    public float GetRotationEntity()
    {
        return Rotation;
    }
}
    