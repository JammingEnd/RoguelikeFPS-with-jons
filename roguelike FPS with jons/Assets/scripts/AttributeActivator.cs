using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeActivator : MonoBehaviour
{
    private PlayerCameraCon player;
    private AttributeManager attributeManager;
    public float activationRange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCameraCon>();
        attributeManager = GameObject.FindGameObjectWithTag("manager").GetComponent<AttributeManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            if(Physics.Raycast(player.transform.position, player.gameObject.transform.TransformDirection(Vector3.forward), out hit, activationRange))
            {
               
                if (hit.collider.tag == "attribute")
                {
                    
                    attributeManager.attributes.Add(hit.collider.gameObject.GetComponent<AttributesObj>());
                    hit.collider.GetComponent<AttributesObj>().OnHitActivate();
                    hit.collider.gameObject.SetActive(false);

                }

            }
        }
    }
}
