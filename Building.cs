using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost;
    public int goldIncrease;
    public float timeBtwIncreases;
    private float nextincreaseTime;
    private GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        nextincreaseTime = Time.time + timeBtwIncreases;
    }
    private void Update()
    {
        if (Time.time > nextincreaseTime)
        {
            nextincreaseTime = Time.time + timeBtwIncreases;
            gm.gold += goldIncrease;
        }
    }
}
