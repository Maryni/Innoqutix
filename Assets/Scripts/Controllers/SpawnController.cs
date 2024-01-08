using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;

    private ObjectPool objectPool;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        var number = Random.Range(min, max+1);
        for(int i=0; i< number; i++)
        {
            var x = Random.Range(250f, Screen.width - 250f);
            var y = Random.Range(100f, Screen.height - 350f);


        }


        
    }
}

