using System;

namespace KosShooter;

public class Shootgun : Weapon
{
    public Shootgun()
    {
        TextureGunWithPlayer = TextureSource.PlayerWithShootgun;
        Damage = 50f;
        RateOfFire = 15;
        MuzzleVelocity = 1400f;
        DelayBetweenShots = RateOfFire;
        WeaponSpread = 1f;
        WeaponStore = 6;
        RemainingBullets = WeaponStore;
        ReloadVelocity = 30;
        DamageDropWithDistance = 0.5f;
    }
    public override void CreateBullet()
    {
        var position = Player.Creature.GetPositionEntity();
        position.X -= 54f*(float)Math.Cos(Player.Creature.GetRotationEntity()+Math.PI/2-0.5f);
        position.Y -= 54f*(float)Math.Sin(Player.Creature.GetRotationEntity()+Math.PI/2-0.5f);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,WeaponSpread,Damage,DamageDropWithDistance));
        position = Player.Creature.GetPositionEntity();
        position.X -= 54f*(float)Math.Cos(Player.Creature.GetRotationEntity()+Math.PI/2+0.5f);
        position.Y -= 54f*(float)Math.Sin(Player.Creature.GetRotationEntity()+Math.PI/2+0.5f);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,WeaponSpread,Damage,DamageDropWithDistance));
        position = Player.Creature.GetPositionEntity();
        position.X -= 54f*(float)Math.Cos(Player.Creature.GetRotationEntity()+Math.PI/2);
        position.Y -= 54f*(float)Math.Sin(Player.Creature.GetRotationEntity()+Math.PI/2);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,WeaponSpread,Damage,DamageDropWithDistance));

    }
}