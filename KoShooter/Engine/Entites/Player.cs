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
    public float MaxHp { get; set; }
    public float CurrentHp { get; set; }
    public float MaxSpecialAbility{ get; private set;}
    public float CurrentSpecialAbility{ get; private set;}
    public int MaxLevelUp{ get; private set;}
    public int CurrentLevelUp{ get; private set;}
    public static readonly Player Creature = new();
    public float RotationSpeed{ get; private set;}
    private Player()
    {
        RotationSpeed = 10f;
        Texture = TextureSource.Player;
        Velocity = 170f;
        MaxHp = 100;
        MaxLevelUp = 50;
        CurrentLevelUp = 0;
        MaxSpecialAbility = 50;
        CurrentSpecialAbility = 0;
        CurrentHp = MaxHp;
        CountKilling = 1;
        _previousCountKilling = 0;
        WeaponInventory.AddWeapon(new Pistol());
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
        if (InputDataComponent.KeyBePressed(Keys.Y))
            CurrentLevelUp+=50;
    }
    private void RotationPlayer()
    {
        var targetAngle = InputDataComponent.GetAngleRotation();
        var rotationDifference = MathHelper.WrapAngle(targetAngle - Rotation);

        var maxRotation = Configurations.IndependentActionsFromFramrate * RotationSpeed*PlayerSkills.Speed;

        var rotationDirection = Math.Sign(rotationDifference);
        var rotationAmount = rotationDirection * Math.Min(Math.Abs(rotationDifference), maxRotation);
        Rotation += rotationAmount;

    }

    public void Move()
    {
        var direction = InputDataComponent.GetMovement();
        if (direction == Vector2.Zero) return;
        direction.Normalize();
        Position += direction * Velocity * Configurations.IndependentActionsFromFramrate*PlayerSkills.Speed;
        Position = Vector2.Clamp(Position, MinPos, MaxPos);
    }

    public Vector2 MinPos { get; set; }
    public Vector2 MaxPos { get; set; }
    public void SetBounds(Point mapSize, Point tileSize)
    {
        MinPos = new((-tileSize.X / 2) + Origin.X, (-tileSize.Y / 2) + Origin.Y);
        MaxPos = new(mapSize.X - (tileSize.X / 2) - Origin.X, mapSize.Y - (tileSize.X / 2) - Origin.Y);
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
        WeaponInventory.CurrentWeapon.Update();
        ReloadGun();
        ChangeWeapon();
        Shoot();
    }
    public void Shoot()
    {
        if (InputDataComponent.IsLeftMouseClicked())
            WeaponInventory.CurrentWeapon.Shoot();
    }

    private void ChangeWeapon()
    {
        WeaponInventory.ChangeGun(InputDataComponent.MouseWheelBeScrolled());
    }
    private void ReloadGun()
    {
       if (InputDataComponent.KeyBePressed(Keys.R))
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
        WeaponInventory.CurrentWeapon.Draw();
    }

    public void UpdateHP()
    {
        MaxHp=MaxHp*(PlayerSkills.HP + PlayerSkills.HP / 50f) / PlayerSkills.HP;
        MaxHp = CurrentHp;
    }

    public void UpdateSpecialAbility()
    {
        MaxSpecialAbility=MaxSpecialAbility*(PlayerSkills.SpecialAbillity + PlayerSkills.SpecialAbillity / 50f) / PlayerSkills.SpecialAbillity;
        CurrentSpecialAbility = MaxSpecialAbility;
    }
}