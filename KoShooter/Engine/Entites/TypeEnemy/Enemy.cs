using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Enemy : Entity,IMovementComponent,IHealthComponent
{
    public float MaxHp { get; set; }
    public float CurrentHp { get; set; }

    public Enemy(Vector2 position)
    {
        Texture = TextureSource.Enemy;
        Position = position;
        Velocity = 150;
        CurrentHp = 100;
    }
    public override void Update()
    {
        base.Update();
        Move();
        FindPlayer();
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (!(CurrentHp <= 0)) return;
        Status = GameStatus.NotExist;
        Player.Creature.CountKilling++;
    }
    
    private void FindPlayer()
    {
        var mousePosition = Player.Creature.Position;
        var direction = Vector2.Normalize(mousePosition - Position);
        var angle = (float)Math.Atan2(direction.Y, direction.X);
        Rotation = angle+(float)Math.PI/2;
    }

    public void Move()
    {
        var positionPlayer = Player.Creature.Position;
        var direction = positionPlayer - Position;
        if (!(direction.Length() > 4)) return;
        direction.Normalize();
        Position += direction * Velocity * Configurations.IndependentActionsFromFramrate;
        Position = Vector2.Clamp(Position, MinPos, MaxPos);
    }

    public Vector2 MinPos { get; set; }
    public Vector2 MaxPos { get; set; }
    public void SetBounds(Point mapSize, Point tileSize)
    {
        MinPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
        MaxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
    }

    public void TakeDamage(float damage)
    {
        CurrentHp -= damage;
        if (CurrentHp < 0)
            CurrentHp = 0;
    }

    public void Heal(float heal)
    {
        CurrentHp += heal;
        if (CurrentHp > MaxHp)
            CurrentHp = MaxHp;
    }
}