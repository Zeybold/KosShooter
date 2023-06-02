using Microsoft.Xna.Framework;
using System;
using System.Net.Mime;
using System.Windows.Forms;
using KosShooter.Engine;
using KosShooter.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public abstract class Enemy : Entity,IMovementComponent,IHealthComponent
{
    public float MaxHp { get; set; }
    public float CurrentHp { get; set; }
    protected EnemyStatus EmStatus{ get; init; }
    protected float Damage{ get; init; }
    protected DropItemSystem DrItSys { get; set; }

    protected Enemy(Vector2 position)
    {
        DrItSys = new DropItemSystem();
        Position = position;
    }
    public override void Update()
    {
        base.Update();
        FindPlayer();
        Move();
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (!(CurrentHp <= 0)) return;
        Status = GameStatus.NotExist;
        var d = DrItSys.DropItem();
        Player.Creature.CountKilling++;
        if (d is not null)
        {
            d.GetPosition(Position);
            //EntityProcessing.Add(d);
        }
    }
    
    private void FindPlayer()
    {
        var playerPosition = Player.Creature.Position;
        var direction = Vector2.Normalize(playerPosition - Position);
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

    public void MakeDamage()
    {
        Player.Creature.TakeDamage(Damage);
    }
}