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
    protected float Damage;
    protected float DamageDropWithDistance;
    
    protected float ReloadVelocity;
    protected float MuzzleVelocity;
    protected float CoolDown;
    protected float DelayBetweenShoot;
    protected float WeaponSpread;
    protected byte WeaponStore;
    protected byte CurrentAmmoInStore;
    public virtual void Shoot()
    {
        if (CoolDown>0) return;
        if (CurrentAmmoInStore == 0)
        {
            Reload();
            return;
        }
        CoolDown = DelayBetweenShoot;
        CurrentAmmoInStore--;
        CreateBullet();
    }

    public override void Update()
    {
        CoolDown -= Configurations.IndependentActionsFromFramrate;
        if (Status == GameStatus.InInventory)
        {
            Position = Player.Creature.Position;
            Rotation = Player.Creature.Rotation-(float)Math.PI/2;
        }
    }

    public void ChangeStatus()
    {
        Status = GameStatus.InInventory;
    }
    public virtual void Reload()
    {
        //ToDo SoundReload
        CoolDown = ReloadVelocity;
        CurrentAmmoInStore = WeaponStore;
    }
    
    public abstract void CreateBullet();
}