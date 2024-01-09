using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private UIController uiController;
    [SerializeField] private DragDrop dragDrop;
    [SerializeField] private EnemyController enemyController;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if(objectPool == null)
        {
            objectPool = FindObjectOfType<ObjectPool>();
        }
        if (uiController == null)
        {
            uiController = FindObjectOfType<UIController>();
        }
        if(player == null)
        {
            player = FindObjectOfType<Player>();
        }
        if(dragDrop == null)
        {
            dragDrop = FindObjectOfType<DragDrop>();
        }
        if(enemyController == null)
        {
            enemyController = FindAnyObjectByType<EnemyController>();
        }

        SetActions();
        
    }

    private void SetActions()
    {
        dragDrop.AddOnDragEnd(
            (value)=> player.SetDirection(value),
            (value)=> player.Jump()
            );
        player.SetOnTriggeredAction(
            ()=> uiController.GameScoreText.GetComponent<TMP_Text>().text = player.CountTriggered.ToString()
            );
        player.SetOnDieAction(
            ()=> uiController.DiePanel.SetActive(true)
            );
        player.SetOnReadyAction(
            ()=> enemyController.StartSpawn()
            );

    }

    public void Ready()
    {
        player.Ready();
    }
}
