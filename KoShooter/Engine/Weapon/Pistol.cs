using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KosShooter;

public class Pistol : Weapon
{
    public Pistol()
    {
        TextureGunWithPlayer = TextureSource.PlayerWithPistols;
        Damage = 10f;
        RateOfFire = 15;
        MuzzleVelocity = 1400f;
        DelayBetweenShots = RateOfFire;
        WeaponSpread = 0.5f;
        WeaponStore = 12;
        RemainingBullets = WeaponStore;
        ReloadVelocity = 30;
        DamageDropWithDistance = 0.7f;
    }
    public override void CreateBullet()
    {
        var position = Player.Creature.GetPositionEntity();
        position.X -= 55f*(float)Math.Cos(Player.Creature.GetRotationEntity()+Math.PI/2-0.5f);
        position.Y -= 55f*(float)Math.Sin(Player.Creature.GetRotationEntity()+Math.PI/2-0.5f);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,WeaponSpread,Damage,DamageDropWithDistance));
        position = Player.Creature.GetPositionEntity();
        position.X -= 55f*(float)Math.Cos(Player.Creature.GetRotationEntity()+Math.PI/2+0.5f);
        position.Y -= 55f*(float)Math.Sin(Player.Creature.GetRotationEntity()+Math.PI/2+0.5f);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,WeaponSpread,Damage,DamageDropWithDistance));
    }
}