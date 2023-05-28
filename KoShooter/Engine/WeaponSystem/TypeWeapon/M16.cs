using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace KosShooter;

public class M16 : Weapon
{
    public M16()
    {
        Texture = TextureSource.M16;
        Status = GameStatus.InInventory;
        
        Damage = 25f;
        DamageDropWithDistance = 20f;
        
        MuzzleVelocity = 1400f;
        
        WeaponSpread = 0.3f;
        WeaponStore = 20;
        CoolDown = 0;
        DelayBetweenShoot = 0.15f;
        CurrentAmmoInStore = WeaponStore;
        ReloadVelocity = 2.5f;

    }

    public override void CreateBullet()
    {
        var position = Player.Creature.Position;
        position.X -= 90f*(float)Math.Cos(Player.Creature.Rotation+Math.PI/2);
        position.Y -= 90f*(float)Math.Sin(Player.Creature.Rotation+Math.PI/2);
        EntityProcessing.Add(new Bullet(position,MuzzleVelocity,WeaponSpread,Damage,DamageDropWithDistance));
    }
}