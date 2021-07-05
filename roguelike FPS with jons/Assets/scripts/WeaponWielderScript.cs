using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWielderScript : MonoBehaviour
{


    public GameObject[] weapons;
    private GameObject currentGun;
    public GameObject gunPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchWeapons();  
    }

    void SwitchWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(currentGun != null && currentGun != weapons[0])
            {
                Destroy(currentGun);
            }
            currentGun = Instantiate(weapons[0], gunPos.transform);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentGun != null && currentGun != weapons[1])
            {
                Destroy(currentGun);
            }
            currentGun = Instantiate(weapons[1], gunPos.transform);

        }
    }
}
