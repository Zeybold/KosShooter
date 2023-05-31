using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KosShooter;

public class Pistol : Weapon
{
    public Pistol()
    {
        Texture = TextureSource.Pistol;
        Status = GameStatus.InInventory;
        
        Damage = 20f;
        DamageDropWithDistance = 10f;
        MuzzleVelocity = 1400f;
        WeaponSpread = 0.25f;
        WeaponStore = 7;
        CoolDown = 0;
        DelayBetweenShoot = 0.25f;
        CurrentAmmoInStore = WeaponStore;
        ReloadVelocity = 1;
    }
    public override void CreateBullet()
    {
        var position = Player.Creature.Position;
        position.X -= 50f*(float)Math.Cos(Player.Creature.Rotation+Math.PI/2);
        position.Y -= 50f*(float)Math.Sin(Player.Creature.Rotation+Math.PI/2);
        var bullet = new Bullet(position, MuzzleVelocity, WeaponSpread*PlayerSkills.SharpShooting, Damage, DamageDropWithDistance);
        bullet.SetBounds(WorldSystem.Map.MapSize,WorldSystem.Map.TileSize);
        EntityProcessing.Add(bullet);
    }
}