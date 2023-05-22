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

public class Player : Entity,IMovement
{
    public static readonly Player Creature = new();
    private WeaponInventory WeaponInventory = new ();
    public PlayerSkills PlayerSkill = new ();
    private Player()
    {
        Texture = TextureSource.Player;
        Position = new Vector2(500, 500);
        Velocity = 150f;
        WeaponInventory.AddWeapon(new Pistol());
        WeaponInventory.AddWeapon(new Shootgun());
    }

    private void ChangeWeapon()
    {
        WeaponInventory.ChangeGun(Mouse.GetState().ScrollWheelValue);
        if (WeaponInventory.CurrentWeapon.TextureGunWithPlayer != Texture)
            Texture = WeaponInventory.CurrentWeapon.TextureGunWithPlayer;
        if (Keyboard.GetState().IsKeyDown(Keys.R))
            WeaponInventory.CurrentWeapon.Reload();
    }

    public override void Update()
    {
        InputData.FreezingTime();
        Move();
        RotationPlayer();
        ChangeWeapon();
        CollisionUpdate();
        WeaponInventory.CurrentWeapon.ShootCooldown();
    }
    private void RotationPlayer()
    {
        Rotation = InputData.GetAngleRotation();
    }
    public void Move()
    {
        var direction = InputData.GetMovement();
        if (direction == Vector2.Zero) return;
        direction.Normalize();
        Position += direction * Velocity * Configurations.IndependentActionsFromFramrate;
    }
}