using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class WorldSystem
{
    List<Weapon> wep = new List<Weapon>();
    public WorldSystem()
    {
        EntityProcessing.Add(new M16(new Vector2(Configurations.ScreenWidth / 2, Configurations.ScreenHeight / 2)));
        EntityProcessing.Add(new Pistol(new Vector2(300,200)));
        EntityProcessing.Add(new Shootgun(new Vector2(300,350)));
        Player.Creature.SetPosition(new Vector2(500,500));
        EntityProcessing.Add(Player.Creature);
        var rnd = new Random();
        /*for (var i = 0; i < 10; i++)
        {
            EntityProcessing.Add(new Enemy(new Vector2(rnd.Next(0,Configurations.ScreenWidth),rnd.Next(0,Configurations.ScreenHeight))));
        }*/
        Mouse.SetCursor(MouseCursor.FromTexture2D(Configurations.ContentGame.Load<Texture2D>("TextureGames/Cursor/aim"),10,10));
        PlayerSkills.ResetCharacter();
    }

    public void Update()
    {
        InputDataComponent.RegistrationKey();
        EntityProcessing.Update();
        PlayerInterface.Update();
    }

    public void Draw()
    {
        EntityProcessing.Draw();
        PlayerInterface.Draw();
    }
}