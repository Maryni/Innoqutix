using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private float ratePerShoot;
    [SerializeField] private ObjectPool objectPool;

    public bool IsEnabled = false;
    private Coroutine shootCoroutine;

    public void StartShoot()
    {
        if(IsEnabled)
        {
           shootCoroutine = StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(ratePerShoot);
        var mod = 1;
        var bullet = objectPool.GetObjectByType(ObjectType.EnemyBullet);
        bullet.transform.position = gameObject.transform.position;
        bullet.SetActive(true);
        if (transform.rotation.y == 180)
        {
            mod = -1;
        }
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10f * mod;
        yield return Shoot();
    }

    public void Stop()
    {
        StopCoroutine(shootCoroutine);
        shootCoroutine = null;
    }
}
