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
    public Vector2 Position { get; protected set; }
    protected float Velocity;
    public float Rotation{ get; protected set; }
    private readonly Vector2[] CollisionRectangle = new Vector2[4];
    protected GameStatus Status = GameStatus.Exist;

    public Vector2 Size => new(Texture.Width, Texture.Height);

    public abstract void Update();
    public virtual void Draw()
    {
        Configurations.SpriteBatch.Draw(Texture, Position, null, Configurations.BaseColor, Rotation, new Vector2(Texture.Width, Texture.Height)/2,1, 0, 0);
    }

    protected void CollisionUpdate()
    {
        CollisionRectangle[0] = new Vector2(Position.X, Position.Y);
        CollisionRectangle[1] = new Vector2(Position.X+Size.X, Position.Y);
        CollisionRectangle[2] = new Vector2(Position.X, Position.Y+Size.Y);
        CollisionRectangle[3] = new Vector2(Position.X+Size.X, Position.Y+Size.Y);
    }
    
    public bool IsExist()
    {
        return Status == GameStatus.Exist;
    }
}
    