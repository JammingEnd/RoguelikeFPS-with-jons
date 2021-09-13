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
        ActivatePlayer();
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
        gunWeight = 10;
        gunMagSize = 10;
        gunMaxSpread = 2;
        gunBurstCount = 3;
        isSemi = false;
        isBurst = false;

        movementSpeed = 5;
        jumpHeight = 5;
        slideDistance = 10;
        sprintSpeed = 4; // 1.5 * Sqrt(Sprintspeed)
    }
    void ActivateWeapon()
    {
        weaponWielder.SwitchWeapons();
        gun = weaponWielder.currentGun.GetComponent<gun>();
        gun.SetVariables(gunMagSize, gunBulletCount, gunDamage, gunFireRate, bulletVelocity, gunReloadSpeed, isSemi, isBurst, gunRecoilH, gunRecoilV, gunMaxSpread, gunBurstCount);

    }
    void ActivatePlayer()
    {
        float finalSpeed = movementSpeed - (Mathf.Sqrt(gunWeight / 10));
        float finalJumpHeight = jumpHeight - (Mathf.Sqrt(gunWeight / 10));
        playerMovement.AssignVariables(finalSpeed, finalJumpHeight, slideDistance, sprintSpeed);
    }

}
