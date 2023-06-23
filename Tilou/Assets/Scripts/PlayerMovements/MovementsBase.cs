using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementsBase : MonoBehaviour
{
    public abstract void EnterState(Movements playerMovements);
    public abstract void UpdateMovements(Movements playerMovements);
}
