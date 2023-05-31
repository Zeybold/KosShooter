using System;
using System.Net.Mime;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using Point = Microsoft.Xna.Framework.Point;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace KosShooter;

public class Bullet : Entity,IMovementComponent
{
    
    private float _damage;
    private readonly float _damageDropWithDistance;
    public Bullet(Vector2 position, float velocity, float weaponSpread, float damage, float damageDropWithDistance)
    {
        Position = position;
        Velocity = velocity;
        Texture = TextureSource.Bullet;
        _damage = damage;
        _damageDropWithDistance = damageDropWithDistance;
        var greatRandom = new Random();
        Rotation = greatRandom
            .NextFloat(-weaponSpread,
                weaponSpread)+Player.Creature.Rotation;
    }
    public override void Update()
    {
        Move();
        LossOfDamage();
        CollisionUpdate();
    }
    private void LossOfDamage()
    {
        _damage -= _damageDropWithDistance*Configurations.IndependentActionsFromFramrate;
        if (_damage<=0)
            Status = GameStatus.NotExist;
    }
    public void Move()
    {
        var direction = Vector2.Zero;
        direction.X += (float)Math.Cos(Rotation-Math.PI/2);
        direction.Y += (float)Math.Sin(Rotation-Math.PI/2);
        direction.Normalize();
        Position += direction * Velocity * Configurations.IndependentActionsFromFramrate;
        if (Position.X < MinPos.X || Position.X > MaxPos.X ||
            Position.Y < MinPos.Y || Position.Y > MaxPos.Y)
        {
            Status = GameStatus.NotExist;
        }
    }

    public Vector2 MinPos { get; set; }
    public Vector2 MaxPos { get; set; }
    public void SetBounds(Point mapSize, Point tileSize)
    {
        MinPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
        MaxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
    }
}