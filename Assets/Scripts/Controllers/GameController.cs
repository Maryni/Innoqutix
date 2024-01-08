using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private UIController uiController;
    private DragDrop dragDrop;

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

        SetActions();
    }

    private void SetActions()
    {
        dragDrop.AddOnDragEnd(
            (value)=> player.Jump(value)
            );
    }
}
