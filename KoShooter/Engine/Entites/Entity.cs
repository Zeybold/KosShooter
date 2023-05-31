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
    protected Vector2 Origin => new(Texture.Width/2, Texture.Height/2);
    public Vector2 Size => new(Texture.Width, Texture.Height);

    public virtual void Update()
    {
        CollisionUpdate();
    }
    public virtual void Draw()
    {
        Configurations.SpriteBatch.Draw(Texture,
            Position,
            null,
            Color.White,
            Rotation,
            Origin,
            Vector2.One,
            SpriteEffects.None,
            0f
        );
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
        return Status is GameStatus.Exist or GameStatus.OnFloor or GameStatus.InInventory;
    }
}
    