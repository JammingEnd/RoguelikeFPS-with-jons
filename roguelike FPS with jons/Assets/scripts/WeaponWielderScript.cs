using UnityEngine;

public class WeaponWielderScript : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject currentGun;
    public GameObject gunPos;


    public void SwitchWeapons()
    {
        if (currentGun != null && currentGun != weapons[0])
        {
            Destroy(currentGun);
        }
        currentGun = Instantiate(weapons[0], gunPos.transform);
    }
}