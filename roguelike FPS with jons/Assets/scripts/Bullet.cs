using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    private float lifetime = 3;
    private PlayerHp enemy;
    private CardHandler cardHandler;
    private string playerName;
    private bool canDamage;
    // private MeshCollider bulletollider;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(GetVisible());
    }

    private IEnumerator GetVisible()
    {
        yield return new WaitForSeconds(0.05f);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        StopAllCoroutines();
    }

    public void BulletStats(float damage, string name, CardHandler handler)
    {
        Damage = damage;
        playerName = name;
        cardHandler = handler;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == playerName)
        {
            NoSelfDamage();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.name == playerName)
        {
            canDamage = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Terrain")
        {
            OnCollision();
            NoSelfDamage();
            return;
        }
        if (canDamage)
        {
            if (collision.gameObject.GetComponent<PlayerHp>() != null)
            {
                Debug.Log("hit");
                enemy = collision.gameObject.GetComponent<PlayerHp>();
                enemy.TakeDamage(Damage);
                Debug.Log(enemy.name);
                foreach (CardBase item in cardHandler.cardBehaviourScriptsRef)
                {
                    if (item != null)
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
                }
            }
        }
    }

    private void NoSelfDamage()
    {
        canDamage = false;
    }

    private void OnCollision()
    {
        Destroy(this.gameObject);
    }
}