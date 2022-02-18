using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IObject
{
    [SerializeField] int healAmount = 10;
    [SerializeField] GameObject potion = null;

    private PlayerEntity player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerEntity>();
    }

    public void Take()
    {
        player.Health.Heal(healAmount);
        Destroy(potion);
    }
}
