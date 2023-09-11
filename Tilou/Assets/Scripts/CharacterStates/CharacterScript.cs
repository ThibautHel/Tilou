using UnityEngine;

[RequireComponent(typeof(CharachterInputs))]
public class CharacterScript : MonoBehaviour
{
    [Header("Scripts")]
    public CharachterInputs Inputs;
    public Shoot ShootScript;
    public WeaponHandler WeaponData;

    [Header("Cameras")]
    public Transform MainCam;
    public Transform AimCam;
    public Transform ThirdPersonCam;

    public float PlayerSpeed = 5f;
    public float TurnVelo;
    public float TurnSmoothTime = .1f;

    public Animator Animator;

    [HideInInspector]
    public StateMachine CharachterSM;
    public State StandingState;
    public State CombatState;
    public State AttackState;
    public State RangedState;
    public State AimingState;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Inputs = gameObject.GetComponent<CharachterInputs>();
        CharachterSM = new StateMachine();
        // StandingState = new StandingState(this);
        CombatState = new CombatState(this);
        AttackState = new AttackState(this);
        RangedState = new RangedState(this);
        AimingState = new AimingState(this);

        CharachterSM.Initialize(CombatState);
    }

    void Update()
    {
        CharachterSM.CurrentState.HandleInput();
        CharachterSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        CharachterSM.CurrentState.PhysicsUpdate();
    }
}
