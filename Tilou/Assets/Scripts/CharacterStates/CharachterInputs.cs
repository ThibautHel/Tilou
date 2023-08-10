using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterInputs : MonoBehaviour
{
    public Vector2 MoveDir = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
}
