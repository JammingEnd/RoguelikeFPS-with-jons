using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEf : MonoBehaviour
{
    private EnemyStatsAndHP enemy;

    public float damage;
    private int totalTicks = 10;
    private int currentTick = 0;



    public void Start()
    {
        enemy = this.gameObject.GetComponent<EnemyStatsAndHP>();
        damage = 10;
        StartCoroutine(Dot());
    }
    IEnumerator Dot()
    {

        while (currentTick < totalTicks)
        {
            enemy.currentHP -= damage;
            currentTick++;
            yield return new WaitForSeconds(1);

        }

    }
}
