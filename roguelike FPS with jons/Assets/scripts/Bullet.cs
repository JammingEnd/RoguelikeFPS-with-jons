using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    private float lifetime = 3;
    private EnemyStatsAndHP enemy;
    private CardHandler cardHandler;
    private MeshCollider bulletollider;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    public void BulletStats(float damage, CardHandler handler)
    {
        Damage = damage;
        cardHandler = handler;
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
            foreach (CardBase item in cardHandler.cardBehaviourScriptsRef)
            {
                if (!item.isBlockCard)
                {
                    Component[] comps;
                    comps = item.behaviourScript.gameObject.GetComponents<Component>();
                    Debug.Log(comps[1].GetType().Name);


                    enemy.gameObject.AddComponent(System.Type.GetType(comps[1].GetType().Name));


                    Destroy(this.gameObject);
                }
                
            }
            if (collision.collider.tag == "Terrain")
            {
                OnCollision();
            }
        }
    }

    
    private void OnCollision()
    {
        Destroy(this.gameObject);
    }
}