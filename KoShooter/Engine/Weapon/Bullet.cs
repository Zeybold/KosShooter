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

public class Bullet : Entity
{
    public float Damage;
    public float DamageDropWithDistance;
    public Bullet(Vector2 position, float velocity, float weaponSpread, float damage, float damageDropWithDistance)
    {
        Position = position;
        Velocity = velocity;
        Texture = TextureSource.Bullet;
        Damage = damage;
        DamageDropWithDistance = damageDropWithDistance;
        var greatRandom = new Random();
        Rotation = RandomUtil.NextFloat(greatRandom,-weaponSpread*Player.Creature.PlayerSkill.SharpShooting,weaponSpread*Player.Creature.PlayerSkill.SharpShooting)+Player.Creature.GetRotationEntity();
    }
    public override void Update(GameTime gameTime)
    {
        Position.X += (float)(Velocity*Math.Cos(Rotation-Math.PI/2));
        Position.Y += (float)(Velocity*Math.Sin(Rotation-Math.PI/2));
        Damage -= DamageDropWithDistance;
        if (Damage<=0)
            isExists = false;
        CollisionUpdate();
    }
}