using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rig2d;

    public int Index { get; set; }
    public bool IsSetted { get; set; }

    private void Start()
    {
        rig2d.isKinematic = true;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>().IsGrounded)
        {
            rig2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
