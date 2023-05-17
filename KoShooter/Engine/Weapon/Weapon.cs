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

public abstract class Weapon
{
    public Texture2D TextureGunWithPlayer;
    public Texture2D TextureGunOnFloor;
    public float Damage;
    public byte RateOfFire;
    public float MuzzleVelocity;
    public byte DelayBetweenShots;
    public float WeaponSpread;
    public byte WeaponStore;
    public byte RemainingBullets;
    public byte ReloadVelocity;
    public float DamageDropWithDistance;

    public virtual void ShootCooldown(GameTime gameTime)
    {
        if (Mouse.GetState().LeftButton == ButtonState.Pressed && DelayBetweenShots==0)
        {
            if (RemainingBullets==0)
                Reload();
            else
            {
                DelayBetweenShots = RateOfFire;
                CreateBullet();
                RemainingBullets--;      
            }
        }
        if (DelayBetweenShots > 0)
            DelayBetweenShots--;
    }
    public virtual void Reload()
    {
        //ToDo SoundReload
        DelayBetweenShots = ReloadVelocity;
        RemainingBullets = WeaponStore;
    }
    public abstract void CreateBullet();
    public virtual Texture2D GetTexturePlayerWithGun()
    {
        return TextureGunWithPlayer;
    }
}