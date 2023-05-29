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
    public ulong CountKilling { get; set; }
    
    private ulong _previousCountKilling;
    public float MaxHp { get; private set;}
    public float CurrentHp{ get; private set; }
    public float MaxSpecialAbility{ get; private set;}
    public float CurrentSpecialAbility{ get; private set;}
    public int MaxLevelUp{ get; private set;}
    public int CurrentLevelUp{ get; private set;}
    public static readonly Player Creature = new();
    private Player()
    {
        Texture = TextureSource.Player;
        Velocity = 170f;
        MaxHp = 100;
        MaxLevelUp = 100;
        CurrentLevelUp = 0;
        MaxSpecialAbility = 50;
        CurrentSpecialAbility = 0;
        CurrentHp = MaxHp;
        CountKilling = 1;
        _previousCountKilling = 0;

    }

    public void SetPosition(Vector2 beginPosition)
    {
        Position = beginPosition;
    }

    public override void Update()
    {
        base.Update();
        CheckLevel();
        SpecialAbility();
        Move();
        WeaponLogistic();
        RotationPlayer();
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

    private void CheckLevel()
    {
        if (CurrentLevelUp >= MaxLevelUp)
        {
            PlayerSkills.LevelUp();
            CurrentLevelUp = 0;
        }

        if (CountKilling > _previousCountKilling)
        {
            _previousCountKilling = CountKilling;
            CurrentLevelUp++;
        }
    }

    private void SpecialAbility()
    {
        if (Configurations.IsFreezeTime)
            if (CurrentSpecialAbility <= 0)
            {
                Configurations.IsFreezeTime = !Configurations.IsFreezeTime;
            }
            else
            {
                CurrentSpecialAbility -= Configurations.Time * 5;
                if (CurrentSpecialAbility < 0)
                    CurrentSpecialAbility = 0;
            }
        else
        {
            CurrentSpecialAbility += Configurations.IndependentActionsFromFramrate*5;
            if (CurrentSpecialAbility > MaxSpecialAbility)
                CurrentSpecialAbility = MaxSpecialAbility;
        }
        if (InputDataComponent.KeyBePressed(Keys.T) && Math.Abs(MaxSpecialAbility - CurrentSpecialAbility) < 0.001)
        {
            Configurations.IsFreezeTime = !Configurations.IsFreezeTime;
        }
    }
    private void WeaponLogistic()
    {
        if (WeaponInventory.CurrentWeapon is null) return;
        WeaponInventory.CurrentWeapon.Update();
        ReloadGun();
        ChangeWeapon();
        Shoot();
    }
    public void Shoot()
    {
        if (InputDataComponent.IsLeftMouseClicked() && WeaponInventory.CurrentWeapon is not null)
            WeaponInventory.CurrentWeapon.Shoot();
    }

    private void ChangeWeapon()
    {
        WeaponInventory.ChangeGun(InputDataComponent.MouseWheelBeScrolled());
    }
    private void ReloadGun()
    {
       if (InputDataComponent.KeyBePressed(Keys.R) && WeaponInventory.CurrentWeapon is not null)
            WeaponInventory.CurrentWeapon.Reload();
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

    public override void Draw()
    {
        base.Draw();
        if (WeaponInventory.CurrentWeapon is not null)
            WeaponInventory.CurrentWeapon.Draw();
    }
}