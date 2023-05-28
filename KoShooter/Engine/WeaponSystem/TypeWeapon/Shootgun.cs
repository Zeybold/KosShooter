using System;

namespace KosShooter;

public class Shootgun : Weapon
{
    public Shootgun()
    {
        Texture = TextureSource.Shootgun;
        Status = GameStatus.InInventory;
        Damage = 50f;
        DamageDropWithDistance = 30f;
        
        MuzzleVelocity = 1400f;
        
        WeaponSpread = 0.7f;
        WeaponStore = 2;
        CoolDown = 0;
        DelayBetweenShoot = 0.2f;
        CurrentAmmoInStore = WeaponStore;
        ReloadVelocity = 2;
    }
    public override void CreateBullet()
    {
        for (var i = 0; i < 5; i++)
        {
            var position = Player.Creature.Position;
            position.X -= 70f*(float)Math.Cos(Player.Creature.Rotation+Math.PI/2);
            position.Y -= 70f*(float)Math.Sin(Player.Creature.Rotation+Math.PI/2);
            EntityProcessing.Add(new Bullet(position,MuzzleVelocity,WeaponSpread,Damage,DamageDropWithDistance));
        }
    }
    
}