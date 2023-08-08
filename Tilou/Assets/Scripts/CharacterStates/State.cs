using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public CharacterScript Player;
    public StateMachine StateMachine;

    public Vector2 MoveInput;
    public State(CharacterScript _player, StateMachine _stateMahine) 
    {
        Player = _player;
        StateMachine = _stateMahine;
    }

    public virtual void Enter() {}
    public virtual void Exit() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void HandleInput() { }

}
