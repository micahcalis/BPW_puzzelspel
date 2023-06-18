using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private GameObject PlayerV;
    Rigidbody2D rb;
    [SerializeField] private Animator Animator;
    private const string WALKBOOL = "Walk";
    [SerializeField] private const string FEET = "feet";
    private bool isTouchingGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float xDirection = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(xDirection, 0.0f);
        rb.velocity = new Vector2(xDirection * movementSpeed, rb.velocity.y);

        if (xDirection > 0.0f)
        {
            PlayerV.transform.localScale = new Vector2(0.21f, 0.21f);
            Animator.SetTrigger(WALKBOOL);
        }
        else if (xDirection < 0.0f)
        {
            PlayerV.transform.localScale = new Vector2(-0.21f, 0.21f);
            Animator.SetTrigger(WALKBOOL);
        }
        else if (xDirection == 0)
        {
            Animator.ResetTrigger(WALKBOOL);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
                Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpForce);
    }
}