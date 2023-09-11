
public interface IHealth
{
    public float MaxHealth { get; }
    public float CurrentHealth { get; }
    public void TakeDmg( 
        float Dmg 
        );
}
