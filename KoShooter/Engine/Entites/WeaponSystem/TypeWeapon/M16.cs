using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KosShooter;

public class M16 : Weapon
{
    public M16()
    {
        WeaponId = WeaponStatus.M16;
        Texture = TextureSource.WeaponList[(int)WeaponId];
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
        CurrentAmmunition = WeaponStore*3;
    }
    public override void UseItem()
    {
        base.UseItem();
        WeaponInventory.AddWeapon(new M16());
    }
}