using Microsoft.Xna.Framework;

namespace KosShooter;

public class Collision
{
    bool IsCollise(Rectangle a , Rectangle b)
    {
        if (a.Contains(b))
            return true;
        return false;
    }
}