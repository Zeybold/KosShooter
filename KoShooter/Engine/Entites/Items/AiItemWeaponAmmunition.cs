using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Mime;
using System.Numerics;
using KosShooter.Engine.Entites.WeaponSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using Vector2 = Microsoft.Xna.Framework.Vector2;
namespace KosShooter.Items;

public class AiItemWeaponAmmunition: AiItem
{
    private readonly int _ammo;
    private readonly Weapon _weapon;
    public AiItemWeaponAmmunition(int Weap = -1)
    {
        Status = GameStatus.OnFloor;
        var typeAmmo = Weap == -1 ? GreatAndFuriousRandom.Next(0, TextureSource.WeaponList.Count) : Weap;
        switch (typeAmmo)
        {
            case (int)WeaponStatus.Pistol:
                _weapon = new Pistol();
                _ammo = GreatAndFuriousRandom.Next(0, 40) * (int)PlayerSkills.Luck;
                Texture = TextureSource.WeaponList[0];
                break;
            case (int)WeaponStatus.M16:
                _weapon = new M16();
                _ammo = GreatAndFuriousRandom.Next(0, 60) * (int)PlayerSkills.Luck;
                Texture = TextureSource.WeaponList[1];
                break;
            case (int)WeaponStatus.DoubleBarrel:
                _weapon = new DoubleBarrel();
                _ammo = GreatAndFuriousRandom.Next(0, 8) * (int)PlayerSkills.Luck;
                Texture = TextureSource.WeaponList[2];
                break;
        }

        _weapon.CurrentAmmunition = _ammo;
    }
    
    public void UseItem()
    {
        WeaponInventory.AddWeapon(_weapon);
        base.UseItem();
    }
}