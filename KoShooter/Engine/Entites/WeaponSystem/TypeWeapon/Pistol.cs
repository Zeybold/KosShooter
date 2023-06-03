using System;
using KosShooter.Engine.Entites.WeaponSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KosShooter;

public class Pistol : Weapon
{
    public Pistol()
    {
        WeaponId = WeaponStatus.Pistol;
        Texture = TextureSource.WeaponList[(int)WeaponId];
        Status = GameStatus.InInventory;
        Damage = 20f;
        DamageDropWithDistance = 10f;
        MuzzleVelocity = 1400f;
        WeaponSpread = 0.25f;
        WeaponStore = 7;
        CoolDown = 0;
        DelayBetweenShoot = 0.25f;
        CurrentAmmoInStore = WeaponStore;
        ReloadVelocity = 1;
        CurrentAmmunition = 99999;
    }

    public override void UseItem()
    {
        base.UseItem();
        WeaponInventory.AddWeapon(new Pistol());
    }
}