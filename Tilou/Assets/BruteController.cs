using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteController : MonoBehaviour
{
    Vector2 MoveDir;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("jump");
        }
        
        MoveDir = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        
        animator.SetFloat("Speed" , MoveDir.y,.1f,Time.deltaTime);
    
    }
}
