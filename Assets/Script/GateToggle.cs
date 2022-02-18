using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateToggle : MonoBehaviour
{
    [SerializeField] int nbToggleNeeded = 0;
    private int nbToggle = 0;

    private void CheckOpen()
    {
        if (nbToggleNeeded == nbToggle)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void AddToggle()
    {
        nbToggle++;
        CheckOpen();
    }

    public void RemoveToggle()
    {
        nbToggle--;
        CheckOpen();
    }

}
