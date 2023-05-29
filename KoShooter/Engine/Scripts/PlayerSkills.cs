namespace KosShooter;

public static class PlayerSkills
{
    public static float SixSence;
    public static float SharpShooting;
    public static float Luck;
    public static float Speed;
    public static float HP;

    public static void ResetCharacter()
    {
        SixSence = 1;
        SharpShooting = 1;
        Luck = 1;
        Speed = 1;
        HP = 1;
    }

    public static void LevelUp()
    {
        SixSence*=0.1f;
        SharpShooting/=0.1f;
        Luck*=0.1f;
        Speed*=0.1f;
        HP*=0.1f;
    }
}