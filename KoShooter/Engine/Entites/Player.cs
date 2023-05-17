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

public class Player : Entity
{
    public static readonly Player Creature = new();
    private WeaponInventory WeaponInventory = new ();
    public PlayerSkills PlayerSkill = new ();
    private Player()
    {
        Texture = TextureSource.Player;
        Position = new Vector2(500, 500);
        Velocity = 3.25f;
        WeaponInventory.AddWeapon(new Pistol());
        WeaponInventory.AddWeapon(new Shootgun());
    }
    private void MovePlayer()
    {
        var direction = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(Keys.W))
            direction.Y-=Velocity*PlayerSkill.Speed;
        if (Keyboard.GetState().IsKeyDown(Keys.A))
            direction.X-=Velocity*PlayerSkill.Speed;
        if (Keyboard.GetState().IsKeyDown(Keys.S))
            direction.Y+=Velocity*PlayerSkill.Speed;
        if (Keyboard.GetState().IsKeyDown(Keys.D))
            direction.X+=Velocity*PlayerSkill.Speed;
        Position += direction;
        WeaponInventory.ChangeGun(Mouse.GetState().ScrollWheelValue);
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
    }

    public override void Update(GameTime gameTime)
    {
        MovePlayer();
        RotationPlayer();
        ChangeWeapon();
        WeaponInventory.CurrentWeapon.ShootCooldown(gameTime);
    }
}