using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpSpeed;

    public bool IsGrounded { get; private set; }
    private Vector2 directionToJump;
    private int countTriggered;
    private Action onTriggeredAction;
    private Action onDie;
    private Action onReady;

    public float X { get; private set; }
    public float Y { get; private set; }
    public int CountTriggered => countTriggered;

    public void Ready()
    {
        rig2D.bodyType = RigidbodyType2D.Dynamic;
        onReady?.Invoke();
    }

    public void Jump()
    {
        if(directionToJump.y > Vector2.zero.y)
        {
            rig2D.velocity = directionToJump * jumpSpeed;
            directionToJump = Vector2.zero;
            animator.SetBool("jump", true);
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
        countTriggered++;
        animator.SetBool("jump",false);
        onTriggeredAction?.Invoke();

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
        Debug.Log("No triggered");
    }

    public void SetOnTriggeredAction(params Action[] actions)
    {
        foreach(var item in actions)
        {
            onTriggeredAction += item;
        }
    }

    public void SetOnDieAction(params Action[] actions)
    {
        foreach (var item in actions)
        {
            onDie += item;
        }
    }

    public void SetOnReadyAction(params Action[] actions)
    {
        foreach (var item in actions)
        {
            onReady += item;
        }
    }

    public void Die()
    {
        onDie?.Invoke();
        rig2D.bodyType = RigidbodyType2D.Kinematic;
    }
}
