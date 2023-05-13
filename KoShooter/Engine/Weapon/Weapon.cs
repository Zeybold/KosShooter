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
    public Texture2D Texture;
    public byte Damage;
    public byte RateOfFire;
    public float MuzzleVelocity;
    public byte Cooldown;
    public float Tochnost;
    public byte Magazine;
    public byte CurrentMagazine;
    public byte ReloadVelocity;
    public virtual void ShootCooldown(GameTime gameTime)
    {
        if (Mouse.GetState().LeftButton == ButtonState.Pressed && Cooldown==0)
        {
            if (CurrentMagazine==0)
                Reload();
            else
            {
                Cooldown = RateOfFire;
                CreateBullet();
                CurrentMagazine--;      
            }
        }
        if (Cooldown > 0)
            Cooldown--;
    }

    public virtual void Reload()
    {
        //ToDo SoundReload
        Cooldown = ReloadVelocity;
        CurrentMagazine = Magazine;
    }
    public abstract void CreateBullet();
    public virtual Texture2D GetTexture()
    {
        return Texture;
    }
}