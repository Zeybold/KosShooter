using System;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace KosShooter.Engine.Entites.WeaponSystem;

public abstract class Weapon : Entity,IItemComponent
{
    protected float Damage;
    protected float DamageDropWithDistance;
    protected WeaponStatus WeaponId;
    protected float ReloadVelocity;
    protected float MuzzleVelocity;
    protected float CoolDown;
    protected float DelayBetweenShoot;
    protected float WeaponSpread;
    protected byte WeaponStore;
    protected byte CurrentAmmoInStore;
    public int CurrentAmmunition { get; protected internal set; }
    
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
        base.Update();
        if (CurrentAmmoInStore == 0)
            Reload();
        if (Configurations.IsFreezeTime)
            CoolDown -= Configurations.IndependentActionsFromFramrate*1.5f;
        else
        {
            CoolDown -= Configurations.IndependentActionsFromFramrate;
        }
    }

    public void WeaponLogicInInventory()
    {
        ChangePosition();
        ChangeRotation();
    }

    private void ChangePosition()
    {
        var xOffset = 60f;
        var yOffset = 0f;
        var offset = Vector2.Transform(new Vector2(xOffset, yOffset), Matrix.CreateRotationZ(Player.Creature.Rotation-(float)Math.PI/2));
        Position = Player.Creature.Position+offset;
    }

    private void ChangeRotation()
    {
        Rotation = Player.Creature.Rotation-(float)Math.PI/2;
    }

    public virtual void UseItem()
    {
        Status = GameStatus.InInventory;
    }
    public virtual void Reload()
    {
        //ToDo SoundReload
        if (CurrentAmmunition - WeaponStore > 0)
        {
            CoolDown = ReloadVelocity;
            CurrentAmmunition = CurrentAmmunition+CurrentAmmoInStore-WeaponStore;
            CurrentAmmoInStore = WeaponStore;
        }
        else
        {
            if (CurrentAmmunition > 0)
            {
                CoolDown = ReloadVelocity;
                CurrentAmmoInStore = (byte)CurrentAmmunition;
                CurrentAmmunition = 0;
            }
        }
    }

    public void FillAmmunition(int ammo)
    {
        CurrentAmmunition += ammo;
    }

    public virtual void CreateBullet()
    {
        var position = Position;
        var weaponOffset = new Vector2(Texture.Width/2, 0);
        var weaponRotationMatrix = Matrix.CreateRotationZ(Rotation);
        weaponOffset = Vector2.Transform(weaponOffset, weaponRotationMatrix);
        var bullet = new Bullet(position + weaponOffset, MuzzleVelocity, WeaponSpread * PlayerSkills.SharpShooting, Damage,
            DamageDropWithDistance);
        bullet.SetBounds(WorldSystem.Map.MapSize,WorldSystem.Map.TileSize);
        EntityProcessing.Add(bullet);
    }
}