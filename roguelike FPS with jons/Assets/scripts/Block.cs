using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public List<GameObject> aquiredBlockCards = new List<GameObject>();

    public float blockCooldown;

    private bool isOnCd;

    // Update is called once per frame
    private void Update()
    {
        if (!isOnCd)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOnCd = true;
                StartCoroutine(Cooldown());
                isOnCd = true;
            }
        }
    }

    private IEnumerator Cooldown()
    {
        while (isOnCd)
        {
            for (int i = 0; i < aquiredBlockCards.Count; i++)
            {
               Instantiate(aquiredBlockCards[i], gameObject.transform.position, gameObject.transform.rotation, this.gameObject.transform);
                
            }
            yield return new WaitForSeconds(blockCooldown);
            isOnCd = false;
            StopAllCoroutines();
        }
    }

    private void AssignVariables(float blockCd)
    {
        blockCooldown = blockCd;
    }
}