using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttributesObj : MonoBehaviour
{
    public bool isGunImprovement, isEffect, isCharacterImprovement;
    public GameObject activationsObj;

    public float reloadSpeedMultiplier;

    private EnemyStatsAndHP enemy;






    public void OnHitActivate()
    {
        if (isGunImprovement)
        {
            reloadSpeedMultiplier = Random.Range(1.1f, 2.5f);

        }

        if (isEffect)
        {

        }

        if (isCharacterImprovement)
        {


        }

        //start corountine for update
    }
}
