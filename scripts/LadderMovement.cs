using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 5f;
    private bool isLadder;
    private bool isClimbing;
    public Animator animator;

    public oyunkontrol oyunK;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if (oyunK.oyunAktif)
        {
        
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

        }
    }

    private void FixedUpdate()
    {
        if (oyunK.oyunAktif)
        {

        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            animator.SetBool("isLadderup", true);
        }
        else
        {
            rb.gravityScale = 1f;
        }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (oyunK.oyunAktif)
        { 
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (oyunK.oyunAktif) { 
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("isLadderup", false);
        }
        }
    }
}
