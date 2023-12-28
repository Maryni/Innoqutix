using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float jumpMod;
    [SerializeField] private float rightMoveMod;
    [SerializeField] private float leftMoveMod;

   
    public void DoJump()
    {
        rigidbody.AddForce(Vector2.up * jumpMod);
    }

    public void DoRightMove()
    {
        rigidbody.AddForce(Vector2.right * rightMoveMod * Time.deltaTime);
    }

    public void DoLeftMove()
    {
        rigidbody.AddForce(Vector2.left * leftMoveMod * Time.deltaTime);
    }

}
