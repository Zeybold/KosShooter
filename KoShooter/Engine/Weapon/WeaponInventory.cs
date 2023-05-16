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

public class WeaponInventory
{
    private Dictionary<byte,Weapon> numberToWeapon = new ();
    private Dictionary<Weapon,byte> WeaponToNumber = new ();
    private int previousScrollValue = 0;
    private byte LengthInventoty = 0;
    public Weapon CurrentWeapon;
    public void AddWeapon(Weapon weapon)
    {
        CurrentWeapon = weapon;
        numberToWeapon.Add((byte)(LengthInventoty+1),weapon);
        WeaponToNumber.Add(weapon,(byte)(LengthInventoty+1));
        LengthInventoty++;
    }

    public void ChangeGun(int mouseWheel)
    {
        CurrentWeapon =(mouseWheel-previousScrollValue) switch
        {
            > 0 => WeaponToNumber[CurrentWeapon] + 1 > LengthInventoty ? 
                numberToWeapon[1] : numberToWeapon[(byte)(WeaponToNumber[CurrentWeapon] + 1)],
            < 0 => WeaponToNumber[CurrentWeapon] - 1 < 1 ? 
                numberToWeapon[LengthInventoty] : numberToWeapon[(byte)(WeaponToNumber[CurrentWeapon] - 1)],
            _ => CurrentWeapon
        };
        previousScrollValue = mouseWheel;
    }
    
}