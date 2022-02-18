using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IObject
{
    [SerializeField] GameObject wall = null;
    [SerializeField] GameObject key = null;
    public void Take()
    {
        wall.SetActive(false);
        Destroy(key);
    }
}
