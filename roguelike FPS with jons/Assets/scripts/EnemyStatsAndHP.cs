using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsAndHP : MonoBehaviour
{


    public float maxHP;

    [HideInInspector]
    public float currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
