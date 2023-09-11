using UnityEngine;

public class State
{
    public CharacterScript Player;
    public bool isMoving;

    public State(CharacterScript _player)
    {
        Player = _player;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void LogicUpdate()
    {
        isMoving = Player.Inputs.MoveDir != Vector2.zero;
    }
    public virtual void PhysicsUpdate() { }
    public virtual void HandleInput() { }

}
