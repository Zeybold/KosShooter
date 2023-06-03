using System;
using KosShooter.Engine.Entites.WeaponSystem;
using Microsoft.Xna.Framework;

namespace KosShooter;

public class DoubleBarrel : Weapon
{
    public DoubleBarrel()
    {
        WeaponId = WeaponStatus.DoubleBarrel;
        Texture = TextureSource.WeaponList[(int)WeaponId];
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
        CurrentAmmunition = WeaponStore*2;
    }
    public override void CreateBullet()
    {
        for (var i = 0; i < 7; i++)
        {
            base.CreateBullet();
        }
    }
    public override void UseItem()
    {
        base.UseItem();
        WeaponInventory.AddWeapon(new DoubleBarrel());
    }
}