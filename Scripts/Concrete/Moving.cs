using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Moving : MonoBehaviour
{

    private Vector3 m_Move;
    public float Speed = 3f;
    public float gravity = 20f;
    public CharacterController characterController;
    public Animator animator;
    public bool IsWalking = false;
    public bool IsJumping = false;
    public bool IsRunning = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = InputManager.InputAxis(InputDirection.HORIZONTAL);
        float h = InputManager.InputAxis(InputDirection.VERTICAL);

        Vector3 desiredMove = h * Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized + v * transform.right;
        if (desiredMove.magnitude > 1f) desiredMove.Normalize();

        if (InputManager.HoldingKey(KeyCode.LeftControl)) desiredMove *= 0.5f;
        if (InputManager.HoldingKey(KeyCode.LeftShift)) { desiredMove *= 1.5f; IsRunning = true; }
        if (InputManager.ReleaseKey(KeyCode.LeftShift)) { IsRunning = false; }

        characterController.Move(desiredMove * Speed * Time.fixedDeltaTime);

    }

    void Update()
    {
        Animation();
    }

    void Animation()
    {

        if (InputManager.HoldingKey(KeyCode.W) || InputManager.HoldingKey(KeyCode.S)) animator.SetBool("Walk", true);

        if (InputManager.HoldingKey(KeyCode.A))
        {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("Walk", true);
        }
        if (InputManager.HoldingKey(KeyCode.D))
        {
            animator.SetBool("WalkRight", true);
            animator.SetBool("Walk", true);
        }

        if (InputManager.ReleaseKey(KeyCode.W) || InputManager.ReleaseKey(KeyCode.S))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Walk", false);
        }

        if (InputManager.ReleaseKey(KeyCode.A) || InputManager.ReleaseKey(KeyCode.D))
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
            animator.SetBool("Walk", false);
        }

        if (InputManager.PressedKey(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }


        if (IsRunning)
        {
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);



    }

}
