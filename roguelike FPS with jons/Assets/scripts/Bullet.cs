using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Currentvelocity;
    private float lifetime = 3;
    private EnemyStatsAndHP enemy;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }
    public void BulletStats(float damage, float velocity)
    {
        Damage = damage;
        Currentvelocity = velocity;
    }
    private void Update()
    {
        this.gameObject.transform.position += transform.forward * Currentvelocity * Time.deltaTime;

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponent<EnemyStatsAndHP>();
            enemy.currentHP -= Damage;
            Destroy(this.gameObject);
        }
    }
  

}
