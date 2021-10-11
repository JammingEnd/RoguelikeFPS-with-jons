using UnityEngine;

public class WeaponWielderScript : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject currentGun;
    public GameObject gunPos;
    private PlayerGui playerGui;
    private gun gun;
    private void Start()
    {
        playerGui = gameObject.GetComponentInParent<PlayerGui>();
       
    }
    private void Update()
    {
        if(currentGun != null)
        {
           
            playerGui.ammoCount.text = gun.currentAmmo.ToString();
           
            playerGui.ammoBar.fillAmount = gun.currentAmmo / gun.magSize;
        }
    }
    public void SwitchWeapons()
    {
        currentGun = Instantiate(weapons[0], gunPos.transform);
       // gun = currentGun.GetComponent<gun>();
    }
}