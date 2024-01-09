using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private List<GameObject> shootEnemyList;
    [SerializeField] private List<GameObject> enabledEnemyList;

    [SerializeField] private float timerPerSpawn;
    private Coroutine spawnCoroutine;

    public void StartSpawn(bool easyMode = false)
    {
        if(!easyMode)
        {
            if(spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(ShowRandomCount());
            }
        }
    }

    public IEnumerator ShowRandomCount()
    {
        yield return new WaitForSeconds(timerPerSpawn);
        foreach(var item in enabledEnemyList)
        {
            item.GetComponent<ShootingEnemy>().Stop();
            item.SetActive(false);
        }
        enabledEnemyList.Clear();

        int number = Random.Range(1, 7);

        for(int i=0; i<number;i++)
        {
            var finded = shootEnemyList.FirstOrDefault(x=>!x.activeSelf);
            finded.SetActive(true);
            var shootScript = finded.GetComponent<ShootingEnemy>();
            shootScript.IsEnabled = true;
            shootScript.StartShoot();

            enabledEnemyList.Add(finded);
        }
        yield return ShowRandomCount();
    }
}
