using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameLevel : MonoBehaviour
{
    public List<GameObject> gameObjectsPoint;
    public List<GameObject> gameObjectsSlot;
    [SerializeField] private Transform parentListObjPoint;
    [SerializeField] private Transform parentListObjSlot;
    private bool canCheck = true;
    public GameObject road;
    public void Start()
    {
        canCheck = true;
        foreach (Transform tr in parentListObjPoint)
        {
            if(tr.gameObject.activeSelf)
                gameObjectsPoint.Add(tr.gameObject);
        }
        foreach (Transform tr in parentListObjSlot)
        {
            gameObjectsSlot.Add(tr.gameObject);
        }
        StartLevel();
    }

    public void RemoveObject(GameObject obj)
    {
        gameObjectsPoint.Remove(obj);
        if (canCheck)
        {
            if (gameObjectsPoint.Count == 0)
            {
                GameManager.Instance.CheckLevelUp();
                canCheck = false;
            }
        }
    }

    public void StartLevel()
    {
        List<GameObject> listObjRandom = new List<GameObject>();
        foreach (GameObject obj in gameObjectsPoint)
        {
            listObjRandom.Add(obj);
        }
        int slot = 0;
        for (int i = 0; i < gameObjectsPoint.Count; i++)
        {
            var x = listObjRandom[Random.Range(0, listObjRandom.Count)];
            listObjRandom.Remove(x);
            slot++;
            if (slot == 3)
                slot = 0;
        }
    }
}
