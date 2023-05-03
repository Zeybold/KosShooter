using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class World
{
    public Player character;
    public Mouses Mouses;
    public World()
    {
        character = new Player();
        Mouses = new Mouses();
    }

    public void Update()
    {
        Mouses.Update();
        character.Update(Mouses.GetPositionMouse());
    }

    public void Draw()
    {
        character.Draw();
        Mouses.Draw();
    }
}