using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class Player : Entity,IMovementComponent,IHealthComponent,IWeaponComponent
{
    public float HP = 100;
    public static readonly Player Creature = new();
    private Player()
    {
        Texture = TextureSource.Player;
        Velocity = 150f;
        WeaponInventory.AddWeapon(new Pistol());
        WeaponInventory.AddWeapon(new Shootgun());
    }

    public void SetPosition(Vector2 beginPosition)
    {
        Position = beginPosition;
    }

    private void ChangeWeapon()
    {
        WeaponInventory.ChangeGun(InputDataComponent.MouseWheelBeScrolled());
        if (WeaponInventory.CurrentWeapon.TextureGunWithPlayer is not null 
            && WeaponInventory.CurrentWeapon.TextureGunWithPlayer != Texture)
            Texture = WeaponInventory.CurrentWeapon.TextureGunWithPlayer;
    }

    public override void Update()
    {
        FreezeTime();
        Move();
        RotationPlayer();
        WeaponInventory.CurrentWeapon.Update();
        //ReloadGun();
        ChangeWeapon();
        CollisionUpdate();
        Shoot();
    }
    
    /*private void ReloadGun()
    {
        if (InputDataComponent.KeyBePressed(Keys.R))
            _weaponInventory.CurrentWeapon();
    }*/
    private void FreezeTime()
    {
        if (InputDataComponent.KeyBePressed(Keys.T))
            Configurations.IsFreezeTime = !Configurations.IsFreezeTime;
    }
    private void RotationPlayer()
    {
        Rotation = InputDataComponent.GetAngleRotation();
    }
    public void Move()
    {
        var direction = InputDataComponent.GetMovement();
        if (direction == Vector2.Zero) return;
        direction.Normalize();
        Position += direction * Velocity * Configurations.IndependentActionsFromFramrate;
    }

    public void TakeDamage(float damage)
    {
        throw new NotImplementedException();
    }

    public void Heal(float heal)
    {
        throw new NotImplementedException();
    }

    public void Shoot()
    {
        if (InputDataComponent.IsLeftMouseClicked())
            WeaponInventory.CurrentWeapon.Shoot();
    }
}