using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private List<GameObject> shootEnemyList;

    public void ShowRandomCount()
    {
        int number = Random.Range(1, 7);

        for(int i=0; i<number;i++)
        {
            var finded = shootEnemyList.FirstOrDefault(x=>!x.activeSelf);
            finded.SetActive(true);
        }
    }
}
