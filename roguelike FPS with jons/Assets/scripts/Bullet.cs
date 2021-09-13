using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    private float lifetime = 3;
    private EnemyStatsAndHP enemy;

    private MeshCollider bulletollider;
    private void Start()
    {
        
        Destroy(this.gameObject, lifetime);
    }
    public void BulletStats(float damage)
    {
        Damage = damage;
    }
   
    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyStatsAndHP>();
            enemy.currentHP -= Damage;
            Destroy(this.gameObject);
            return;
        }
        if (collision.collider.tag == "Terrain")
        {
            OnCollision();
        }
    }
    void OnCollision()
    {
        Destroy(this.gameObject);
    }


}
