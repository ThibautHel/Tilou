using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public Vector3 MoveDir { get; private set; } = Vector3.zero;
    public float RotationDir { get; private set; }
    public float AngleInRad { get; private set; }

    private void Update()
    {
        MoveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }
}
