using KosShooter.Items;
using Microsoft.Xna.Framework;

namespace KosShooter;

public class Reptile : Enemy
{
    public Reptile(Vector2 position) : base(position)
    {
        EmStatus = EnemyStatus.Reptile;
        Texture = TextureSource.Enemies[(int)EmStatus];
        Velocity = 120;
        Damage = 20;
        MaxHp = 30;
        CurrentHp = MaxHp;
        DrItSys.AddItem(new AiItemWeaponAmmunition(),0.6f);
        DrItSys.AddItem(new AiItemAidKit(),0.0005f);
        DrItSys.AddItem(new AiItemWeaponAmmunition(1),0.25f);
    }
}