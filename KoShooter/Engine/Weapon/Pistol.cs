using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KosShooter;

public class Pistol : Weapon
{
    public Pistol()
    {
        Texture = TextureSource.PlayerWithPistols;
        Damage = 10;
        RateOfFire = 15;
        MuzzleVelocity = 16.5f;
        Cooldown = RateOfFire;
        Tochnost = 0.5f;
        Magazine = 15;
        CurrentMagazine = Magazine;
        ReloadVelocity = 30;
    }
    public override void CreateBullet()
    {
        var position = Player.Creature.GetPositionEntity();
        position.X -= 54f*(float)Math.Cos(Player.Creature.GetRotationEntity()+Math.PI/2-0.5f);
        position.Y -= 54f*(float)Math.Sin(Player.Creature.GetRotationEntity()+Math.PI/2-0.5f);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,Tochnost));
        position = Player.Creature.GetPositionEntity();
        position.X -= 54f*(float)Math.Cos(Player.Creature.GetRotationEntity()+Math.PI/2+0.5f);
        position.Y -= 54f*(float)Math.Sin(Player.Creature.GetRotationEntity()+Math.PI/2+0.5f);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,Tochnost));
    }
}