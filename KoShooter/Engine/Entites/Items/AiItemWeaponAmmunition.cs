using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Mime;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using Vector2 = Microsoft.Xna.Framework.Vector2;
namespace KosShooter.Items;

public class AiItemWeaponAmmunition: AiItem
{
    private int Ammo;
    public Weapon Weapon;
    public AiItemWeaponAmmunition(int Weap = 0)
    {
        Status = GameStatus.OnFloor;
        int typeAmmo;
        if (Weap == 0)
        {
            typeAmmo = GreatAndFuriousRandom.Next(0, TextureSource.WeaponList.Count);
        }
        else
        {
            typeAmmo = Weap;
        }
        switch (typeAmmo)
        {
            case (int)WeaponStatus.Pistol:
                Weapon = new Pistol();
                Ammo = GreatAndFuriousRandom.Next(0, 40) * (int)PlayerSkills.Luck;
                break;
            case (int)WeaponStatus.M16:
                Weapon = new M16();
                Ammo = GreatAndFuriousRandom.Next(0, 60) * (int)PlayerSkills.Luck;
                break;
            case (int)WeaponStatus.DoubleBarrel:
                Weapon = new DoubleBarrel();
                Ammo = GreatAndFuriousRandom.Next(0, 8) * (int)PlayerSkills.Luck;
                break;
        }

        Weapon.CurrentAmmunition = Ammo;
    }
    
    public void UseItem()
    {
        WeaponInventory.AddWeapon(Weapon);
        base.UseItem();
    }
}