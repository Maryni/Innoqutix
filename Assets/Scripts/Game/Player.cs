using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private float jumpSpeed;

    public bool IsGrounded { get; private set; }
    private Vector2 directionToJump;

    public float X { get; private set; }
    public float Y { get; private set; }

    private void Update()
    {
        if(IsGrounded)
        {
            //Jump();
            Debug.Log("1");
        }
    }

    public void Jump()
    {
        if(directionToJump.y > Vector2.zero.y)
        {
            rig2D.velocity = directionToJump * jumpSpeed;
            directionToJump = Vector2.zero;
        }
        else
        {
            rig2D.velocity = Vector2.up * jumpSpeed;
            directionToJump = Vector2.zero;
        }
    }

    public void SetDirection(Vector2 direction) => directionToJump = direction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
        Debug.Log("IsTriggered");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
        Debug.Log("No triggered");
    }
}
