using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    private PlayerGui playerGui;


    private float maxHp;
    private float currenthp;

    private void Start()
    {
        playerGui = GetComponentInChildren<PlayerGui>();
    }
    public void SetStat(float HpAmount)
    {
        maxHp = HpAmount;
        currenthp = maxHp;
    }

    public void TakeDamage(float _damage)
    {
        currenthp = _damage;
        playerGui.healthBar.fillAmount = currenthp / maxHp;

    }
}
