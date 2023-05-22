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
    private void RotationPlayer()
    {
        var mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        var direction = Vector2.Normalize(mousePosition - Position);
        var angle = (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI/2;
        Rotation = angle;
    }
    
    private void ChangeWeapon()
    {
        WeaponInventory.ChangeGun(Mouse.GetState().ScrollWheelValue);
        if (WeaponInventory.CurrentWeapon.TextureGunWithPlayer != Texture)
            Texture = WeaponInventory.CurrentWeapon.TextureGunWithPlayer;
        if (Keyboard.GetState().IsKeyDown(Keys.R))
            WeaponInventory.CurrentWeapon.Reload();
    }

    public override void Update(GameTime gameTime)
    {
        Move(gameTime);
        RotationPlayer();
        ChangeWeapon();
        CollisionUpdate();
        WeaponInventory.CurrentWeapon.ShootCooldown(gameTime);
    }

    public void Move(GameTime gameTime)
    {
        var direction = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(Keys.W))
            direction.Y--;
        if (Keyboard.GetState().IsKeyDown(Keys.A))
            direction.X--;
        if (Keyboard.GetState().IsKeyDown(Keys.S))
            direction.Y++;
        if (Keyboard.GetState().IsKeyDown(Keys.D))
            direction.X++;
        Position += direction * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}