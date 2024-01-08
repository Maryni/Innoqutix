using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public GameObject arrowPrefab;
    [SerializeField] private GameObject startPlatform;
    #region private variables
    
    private Action<Vector2> actionOnEndDrag;
    private GameObject arrowInstance;
    private RectTransform rectTransform;
    private int lastX = -1;
    private int lastY = -1;
    private Vector2 startPos;
    private Vector2 directionToJump;

    #endregion private variables

    #region properties

    public Vector2 DirectionToJump => directionToJump;

    #endregion properties

    #region public functions

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (arrowInstance == null)
        {
            arrowInstance = Instantiate(arrowPrefab, rectTransform.position, rectTransform.rotation, transform.parent);
        }
        else
        {
            arrowInstance.SetActive(true);
        }
        startPos = eventData.position;

        Debug.Log($"lastX = {lastX} | lastY = {lastY}");
        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Player>())
        {            
            int x = (int) eventData.pointerCurrentRaycast.gameObject.GetComponent<Player>().X;
            int y = (int) eventData.pointerCurrentRaycast.gameObject.GetComponent<Player>().Y;
            if (lastX == -1 && lastY == -1)
            {
                lastX = x;
                lastY = y;
                Debug.Log($"[OnBeginDrag] complete");
            }
            
            Debug.Log($"[OnBeginDrag] first point X = {lastX} | Y = {lastY}");
        }
        else
        {
            Debug.Log("wrong gameobject");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Player>())
            {
                int x = (int) eventData.pointerCurrentRaycast.gameObject.GetComponent<Player>().X;
                int y = (int) eventData.pointerCurrentRaycast.gameObject.GetComponent<Player>().Y;
                Debug.Log("OnEndDrag called");
                lastX = -1; //x
                lastY = -1;
            
            }
        }
        if(arrowInstance != null)
        {
            arrowInstance.SetActive(false);
        }
        actionOnEndDrag.Invoke(directionToJump);

        if(startPlatform.activeSelf)
        {
            startPlatform.SetActive(false);
        }
        Debug.Log($"[OnEndDrag] lastX ={lastX} | lastY = {lastY}" );
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.position = eventData.position; 
        Vector2 direction = eventData.position - startPos;
        directionToJump = direction;
        directionToJump.Normalize();
        directionToJump = -directionToJump;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowInstance.transform.rotation = Quaternion.Euler(0, 0, angle + 180);
    }

    public void AddOnDragEnd(params Action<Vector2>[] actions)
    {
        foreach(var item in actions)
        {
            actionOnEndDrag += item;
        }
    }

    #endregion public functions
}
