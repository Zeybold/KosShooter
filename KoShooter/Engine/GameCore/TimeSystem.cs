using System;
using System.Data;
using Microsoft.Xna.Framework;

namespace KosShooter;

public static class TimeSystem
{
    public static float Min = 0.05f;
    public static float Max = 1f;
    public static float TimeDelationSpeed = 1f;
    public static float TimeDelationSpeedPerSecond = (Max - Min) / TimeDelationSpeed;
    public static float TimeDelation = 1f;
    public static float Time;
    public static float FreezeTime;

    public static void Update(GameTime gameTime)
    {
        Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (Configurations.IsFreezeTime)
        {
            TimeDelation -= TimeDelationSpeedPerSecond * Time;
        }
        else
        {
            TimeDelation+=TimeDelationSpeedPerSecond * Time;
        }

        TimeDelation = Math.Clamp(TimeDelation, Min, Max);
        FreezeTime = TimeDelation * Time;
    }
}