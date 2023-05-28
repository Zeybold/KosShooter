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
    public float MaxHp { get; private set;}
    public float CurrentHp{ get; private set; }
    public static readonly Player Creature = new();
    private Player()
    {
        Texture = TextureSource.Player;
        Velocity = 170f;
        MaxHp = 100;
        CurrentHp = MaxHp;
        WeaponInventory.AddWeapon(new Pistol());
        WeaponInventory.AddWeapon(new Shootgun());
        WeaponInventory.AddWeapon(new M16());
    }

    public void SetPosition(Vector2 beginPosition)
    {
        Position = beginPosition;
    }

    private void ChangeWeapon()
    {
        WeaponInventory.ChangeGun(InputDataComponent.MouseWheelBeScrolled());
    }

    public override void Update()
    {
        FreezeTime();
        Move();
        WeaponLogistic();
        RotationPlayer();
        CollisionUpdate();
        if (InputDataComponent.KeyBePressed(Keys.H))
            TakeDamage(10);
        if (InputDataComponent.KeyBePressed(Keys.F))
            Heal(10);
    }
    private void WeaponLogistic()
    {
        WeaponInventory.CurrentWeapon.Update();
        ReloadGun();
        ChangeWeapon();
        Shoot();
    }
    private void ReloadGun()
    {
       if (InputDataComponent.KeyBePressed(Keys.R))
            WeaponInventory.CurrentWeapon.Reload();
    }
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
        CurrentHp -= damage;
        if (CurrentHp < 0)
            CurrentHp = 0;
    }

    public void Heal(float heal)
    {
        CurrentHp += heal;
        if (CurrentHp > MaxHp)
            CurrentHp = MaxHp;
    }

    public void Shoot()
    {
        if (InputDataComponent.IsLeftMouseClicked())
            WeaponInventory.CurrentWeapon.Shoot();
    }

    public override void Draw()
    {
        base.Draw();
        WeaponInventory.CurrentWeapon.Draw();
    }
}