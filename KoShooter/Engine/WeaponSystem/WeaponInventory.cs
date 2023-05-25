using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Net.Sockets;
using System.Security.Policy;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public static class WeaponInventory
{
    private static Dictionary<byte,Weapon> numberToWeapon = new ();
    private static Dictionary<Weapon,byte> WeaponToNumber = new ();
    private static int _previousScrollValue;
    private static byte _lengthInventory;
    public static Weapon CurrentWeapon;
    public static void AddWeapon(Weapon weapon)
    {
        if (WeaponToNumber.ContainsKey(weapon)) return;
        CurrentWeapon = weapon;
        numberToWeapon.Add((byte)(_lengthInventory+1),weapon);
        WeaponToNumber.Add(weapon,(byte)(_lengthInventory+1));
        _lengthInventory++;
    }

    public static void ChangeGun(int mouseWheel)
    {
        CurrentWeapon =(mouseWheel-_previousScrollValue) switch
        {
            > 0 => WeaponToNumber[CurrentWeapon] + 1 > _lengthInventory ? 
                numberToWeapon[1] : numberToWeapon[(byte)(WeaponToNumber[CurrentWeapon] + 1)],
            < 0 => WeaponToNumber[CurrentWeapon] - 1 < 1 ? 
                numberToWeapon[_lengthInventory] : numberToWeapon[(byte)(WeaponToNumber[CurrentWeapon] - 1)],
            _ => CurrentWeapon
        };
        _previousScrollValue = mouseWheel;
    }
}