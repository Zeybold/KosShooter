using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KosShooter;

public class M16 : Weapon
{
    public M16(Vector2 position)
    {
        Position = position;
        Texture = TextureSource.M16;
        Status = GameStatus.OnFloor;
        
        Damage = 25f;
        DamageDropWithDistance = 20f;
        
        MuzzleVelocity = 1400f;
        
        WeaponSpread = 0.3f;
        WeaponStore = 20;
        CoolDown = 0;
        DelayBetweenShoot = 0.15f;
        CurrentAmmoInStore = WeaponStore;
        ReloadVelocity = 2.5f;

    }

    public override void CreateBullet()
    {
        var position = Player.Creature.Position;
        var bullet = new Bullet(position, MuzzleVelocity, WeaponSpread * PlayerSkills.SharpShooting, Damage,
            DamageDropWithDistance);
        bullet.SetBounds(WorldSystem.Map.MapSize,WorldSystem.Map.TileSize);
        EntityProcessing.Add(bullet);
    }
}