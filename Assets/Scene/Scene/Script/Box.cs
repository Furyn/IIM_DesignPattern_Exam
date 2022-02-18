using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    [SerializeField] GameObject potion = null;

    public void Touch(int power)
    {
        int rand = Random.Range(0,3);
        if (rand == 0)
        {
            Instantiate(potion,transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
