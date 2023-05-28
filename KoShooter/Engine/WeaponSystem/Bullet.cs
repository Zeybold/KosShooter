using System;
using System.Net.Mime;
using System.Security.Policy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
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
            .NextFloat(-weaponSpread*PlayerSkills.SharpShooting,
                weaponSpread*PlayerSkills.SharpShooting)+Player.Creature.Rotation;
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
    }
}