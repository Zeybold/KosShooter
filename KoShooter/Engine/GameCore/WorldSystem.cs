using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class WorldSystem
{
    public WorldSystem()
    {
        Player.Creature.SetPosition(new Vector2(500,500));
        EntityProcessing.Add(Player.Creature);
        var rnd = new Random();
        /*for (var i = 0; i < 100; i++)
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