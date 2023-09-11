using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance { get; private set; }

    public CharacterScript Player;

    private void Awake()
    {
        // Ensure only one instance of AnimationManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This keeps the GameObject persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }
}
