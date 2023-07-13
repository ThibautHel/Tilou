
public interface IHealth
{
    public float MaxHealth { get; }
    public float CurrentHealth { get; set; }
    public void TakeDmg( 
        float Dmg 
        );
}
