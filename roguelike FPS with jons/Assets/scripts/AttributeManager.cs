using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    // Start is called before the first frame update

   public List<AttributesObj> attributes = new List<AttributesObj>();

    private gun gun;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            gun = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponWielderScript>().currentGun.GetComponent<gun>();

            float reloadMulti = 1;
            foreach (var getVariable in attributes)
            {
                reloadMulti += getVariable.reloadSpeedMultiplier;
            }
            gun.reloadSpeedMultiplier = reloadMulti;
        }
    }


}
