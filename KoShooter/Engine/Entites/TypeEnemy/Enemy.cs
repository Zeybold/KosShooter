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
    public float MaxHP{ get; private set; }
    public float CurrentHP{ get; private set; }
    public Enemy(Vector2 position)
    {
        Texture = TextureSource.Enemy;
        Position = position;
        Velocity = 150;
        CurrentHP = 100;
    }
    public override void Update()
    {
        Move();
        FindPlayer();
        CollisionUpdate();
        if (CurrentHP<=0)
            Status = GameStatus.NotExist;
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
    }

    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP < 0)
            CurrentHP = 0;
    }

    public void Heal(float heal)
    {
        CurrentHP += heal;
        if (CurrentHP > MaxHP)
            CurrentHP = MaxHP;
    }
}