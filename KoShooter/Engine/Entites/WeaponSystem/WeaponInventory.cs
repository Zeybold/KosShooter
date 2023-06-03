using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Net.Sockets;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using KosShooter.Engine.Entites.WeaponSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public static class WeaponInventory
{
    private static Dictionary<int,Weapon> numberToWeapon = new ();
    private static Dictionary<Weapon,int> WeaponToNumber = new ();
    private static int _previousScrollValue;
    private static int _lengthInventory;
    public static Weapon CurrentWeapon { get; private set; }
    public static void AddWeapon(Weapon weapon)
    {
        if (WeaponToNumber.ContainsKey(weapon))
        {
            numberToWeapon[WeaponToNumber[weapon]].FillAmmunition(weapon.CurrentAmmunition);
        };
        CurrentWeapon = weapon;
        numberToWeapon.Add(_lengthInventory+1,weapon);
        WeaponToNumber.Add(weapon,_lengthInventory+1);
        _lengthInventory++;
    }

    public static void UpdatePositionGun()
    {
        foreach (var el in numberToWeapon)
            el.Value.WeaponLogicInInventory();
    }

    public static void ChangeGun(int mouseWheel)
    {
        CurrentWeapon =(mouseWheel-_previousScrollValue) switch
        {
            > 0 => WeaponToNumber[CurrentWeapon] + 1 > _lengthInventory ? 
                numberToWeapon[1] : numberToWeapon[WeaponToNumber[CurrentWeapon] + 1],
            < 0 => WeaponToNumber[CurrentWeapon] - 1 < 1 ? 
                numberToWeapon[_lengthInventory] : numberToWeapon[WeaponToNumber[CurrentWeapon] - 1],
            _ => CurrentWeapon
        };
        _previousScrollValue = mouseWheel;
    }
}