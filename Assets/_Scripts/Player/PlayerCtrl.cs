using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //public float moveSpeed = 5f;
    public float jumpFroce = 15f;
    private bool isGround;
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerStats playerStats;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerStats = GetComponent<PlayerStats>();

    }
    void FixedUpdate()
    {
        HandleMove();
    }
    void Update()
    {
        HandleJump();
        HandleAnimaton();
    }
    public void HandleMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * playerStats.moveSpeed, rb.velocity.y);
        //Flip
        if (moveX < 0) transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else if (moveX > 0) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void HandleJump()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (Input.GetKey(KeyCode.W) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpFroce);
        }
    }

    public void HandleAnimaton()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGround;
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsJumping", isJumping);
    }
}
