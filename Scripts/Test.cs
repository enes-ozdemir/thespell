using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Animator animator;
    public bool state = false;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(InputManager.PressedKey(KeyCode.Space))
        {
            //animator.SetTrigger("Howl");
            //animator.SetBool("Howl", state);
            animator.SetTrigger("PickupRock");
            
        }

        if (InputManager.PressedKey(KeyCode.LeftControl))
            animator.SetTrigger("ThrowRock");

        if (InputManager.PressedKey(KeyCode.LeftShift))
            animator.SetTrigger("GetHitHoldRock");

        if (InputManager.PressedKey(KeyCode.W))
        {
            state = !state;
            animator.SetBool("Walk", state);
        }

        if (InputManager.PressedKey(KeyCode.S))
            animator.SetTrigger("Attack3Hit");

        if (InputManager.PressedKey(KeyCode.F))
            animator.SetTrigger("Death");
    }
}
