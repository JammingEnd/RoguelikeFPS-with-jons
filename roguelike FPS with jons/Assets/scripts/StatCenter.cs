using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCenter : MonoBehaviour
{
    public static string playerName;

    [Header("Combat variables")]

    public float gunDamage, bulletVelocity, gunFireRate, gunReloadSpeed, gunRecoilH, gunRecoilV, gunWeight, bulletLifetime, gunMaxSpread; //firerate is in seconds, reloadspeed too
    public int gunMagSize, gunBulletCount, gunBurstCount;
    public bool isSemi, isBurst;
    [Header("Pysical stats")]

    public float health, movementSpeed, slideDistance, jumpHeight, sprintSpeed;

    [Header("Blocking")]
    public float blockCooldown;
    public int blockCount;
    public bool isDoubleShield; //for things that use 1 card

    private WeaponWielderScript weaponWielder;
    private gun gun;

    private PlayerMovementController playerMovement;

    void Start()
    {
        playerName = "Pierre";
        this.gameObject.name = playerName;

        weaponWielder = gameObject.GetComponentInChildren<WeaponWielderScript>();
        playerMovement = gameObject.GetComponent<PlayerMovementController>();
        //temp
        DefaultStat();

        ActivateWeapon();

    }

    void DefaultStat()
    {
        gunDamage = 30;
        gunBulletCount = 2;
        bulletVelocity = 10;
        gunFireRate = 0.2f; //0.2 * 60 because its in seconds;
        gunReloadSpeed = 3;
        gunRecoilH = 2;
        gunRecoilV = 4;
        //gunWeight = ;
        gunMagSize = 10;
        gunMaxSpread = 2;
        isSemi = false;
        isBurst = false;

        movementSpeed = 4;
        jumpHeight = 4;
        slideDistance = 10;
        sprintSpeed = 4; // 1.5 * Sqrt(Sprintspeed)
    }
   // Update is called once per frame
    void Update()
    {
        
    }
    void ActivateWeapon()
    {
        weaponWielder.SwitchWeapons();
        gun = weaponWielder.currentGun.GetComponent<gun>();
        gun.SetVariables(gunMagSize, gunBulletCount, gunDamage, gunFireRate, bulletVelocity, gunReloadSpeed, isSemi, isBurst, gunRecoilH, gunRecoilV, gunMaxSpread);

    }
    void ActivatePlayer()
    {
        playerMovement.AssignVariables(movementSpeed, jumpHeight, slideDistance, sprintSpeed);
    }

}
