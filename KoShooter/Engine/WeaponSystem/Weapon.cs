using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Design.Serialization;
using System.Net.Mime;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace KosShooter;

public abstract class Weapon : Entity
{
    public Texture2D TextureGunWithPlayer;
    public float Damage;
    public byte RateOfFire;
    public float MuzzleVelocity;
    
    public float CoolDown;
    public float DelayBetweenShoot;
    
    public float WeaponSpread;
    public byte WeaponStore;
    public byte ReloadVelocity;
    public float DamageDropWithDistance;
    public virtual void Shoot()
    {
        if (CoolDown>0) return;
        CoolDown = DelayBetweenShoot;
        CreateBullet();
    }

    public override void Update()
    {
        CoolDown -= Configurations.IndependentActionsFromFramrate;
    }

    /*public virtual void Reload()
    {
        //ToDo SoundReload
        DelayBetweenShots = ReloadVelocity;
        RemainingBullets = WeaponStore;
    }*/
    
    public abstract void CreateBullet();
    public Texture2D GetTexturePlayerWithGun()
    {
        return TextureGunWithPlayer;
    }
}