using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().Die();
            gameObject.SetActive(false);
        }
        if(collision.gameObject.layer == 7)
        {
            gameObject.SetActive(false);
        }
    }
}

