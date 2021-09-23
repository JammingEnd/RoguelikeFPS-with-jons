using UnityEngine;

public class StatCenter : MonoBehaviour
{
    public static string playerName;

    [Header("Combat variables")]
    public bool isSemi, isBurst;

    public int gunMagSize { get; set; }
    public int gunBulletCount { get; set; }
    public int gunBurstCount { get; set; }
    public float bulletVelocity { get; set; }

    public float gunDamage { get; set; }
    public float gunFireRate { get; set; }
    public float gunReloadSpeed { get; set; }
    public float gunRecoilH { get; set; }
    public float gunRecoilV { get; set; }
    public float gunWeight { get; set; }
    public float bulletLifetime { get; set; }
    public float gunMaxSpread { get; set; }

    // [("Pysical stats")]
    public float sprintSpeed { get; set; }

    public float health { get; set; }
    public float movementSpeed { get; set; }
    public float slideDistance { get; set; }
    public float jumpHeight { get; set; }

    [Header("Blocking")]
    public bool isDoubleShield; //for things that use 1 card

    public float blockCooldown { get; set; }

    public int blockCount { get; set; }

    private WeaponWielderScript weaponWielder;
    private gun gun;
    private CardHandler cardHandler;
    private PlayerHp playerHp;
    private PlayerMovementController playerMovement;
    private Block block;

    private void Start()
    {
        playerName = "Pierre";
        this.gameObject.name = playerName;

        weaponWielder = gameObject.GetComponentInChildren<WeaponWielderScript>();
        playerMovement = gameObject.GetComponent<PlayerMovementController>();
        cardHandler = gameObject.GetComponent<CardHandler>();
        playerHp = gameObject.GetComponent<PlayerHp>();
        block = gameObject.GetComponent<Block>();
        //temp
        DefaultStat();

        ActivateWeapon();
        ActivatePlayer();
        ActivateHealth();
        ActivateBlock();
    }

    public void SetVariablesFromCard(string varName, float amount)
    {
         var prop = this.GetType().GetProperty(varName);
         object o = prop.GetValue(this);
         float f = (float)o;

        prop.SetValue(this, f *= amount);
        PostVariables();
    }
    public void PostVariables()
    {
        ActivateWeapon();
        ActivatePlayer();
        ActivateHealth();
        ActivateBlock();
    }
    public void DefaultStat()
    {
        gunDamage = 30;
        gunBulletCount = 1;
        bulletVelocity = 10;
        gunFireRate = 100f; //100 / Gunfirerate(100) = 1 shot per second
        gunReloadSpeed = 3;
        gunRecoilH = 2;
        gunRecoilV = 4;
        gunWeight = 10;
        gunMagSize = 10;
        gunMaxSpread = 2;
        gunBurstCount = 1;
        isSemi = false;
        isBurst = false;

        movementSpeed = 5;
        jumpHeight = 5;
        slideDistance = 10;
        sprintSpeed = 4; // 1.5 * Sqrt(Sprintspeed)

        health = 100;
    }

    private void ActivateWeapon()
    {
        float finalFr = Mathf.Sqrt((60 / gunFireRate));
        weaponWielder.SwitchWeapons();
        gun = weaponWielder.currentGun.GetComponent<gun>();
        gun.SetVariables(gunMagSize, gunBulletCount, gunDamage, finalFr, bulletVelocity, gunReloadSpeed, isSemi, isBurst, gunRecoilH, gunRecoilV, gunMaxSpread, gunBurstCount, cardHandler);
    }

    private void ActivatePlayer()
    {
        float finalSpeed = (10 * Mathf.Sqrt(movementSpeed / 10)) - (Mathf.Sqrt(gunWeight / 10));
        float finalJumpHeight = jumpHeight - (Mathf.Sqrt(gunWeight / 10));
        playerMovement.AssignVariables(finalSpeed, finalJumpHeight, slideDistance, sprintSpeed);
    }
    private void ActivateHealth()
    {
        playerHp.SetStat(health);
    }
    private void ActivateBlock()
    {
        block.AssignVariables(blockCooldown);
    }
}