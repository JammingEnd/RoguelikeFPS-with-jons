using System.Collections;
using UnityEngine;

public class gun : MonoBehaviour
{
    private int magSize;
    private int currentAmmo;
    private float damage;
    private float fireRate;
    private float Maxrange;
    private float minRange;
    private float velocity;
    private float reloadSpeed;
    private float Hrecoil, Vrecoil;
    private int bulletCount; //bullets is like pellets in a slug
    private float maxSpread;

    private bool isSemi, isBurst;
    private int burstCount;
    private bool isSemiBurst = false;

    //  private Animation reloadAnim;
    private Animator animController;

    public GameObject muzzlePlace;
    public GameObject magPlace;
    public GameObject currentMag;

    #region AttachmentVariables

    /*
    [Header("Attachment stuff")]
    public List<AttachmentScripts> sightsObj = new List<AttachmentScripts>();

    public List<AttachmentScripts> magObjs = new List<AttachmentScripts>();
    public List<AttachmentScripts> muzzleObjs = new List<AttachmentScripts>();
    public List<AttachmentScripts> otherObjs = new List<AttachmentScripts>();
    public GameObject sightPlace;

    public GameObject otherPlace;
    private GameObject currentSight;

    private GameObject currentMuzzle;
    private GameObject currentOther;
    private AttachmentScripts currentSightScript, currentMagScript, currentMuzzleScript, currentOtherScript;

    private int indexSights;
    private int indexMags;
    private int indexMuzzles;
    private int indexOthers;
    */

    #endregion AttachmentVariables

    [Header("other stuff, bullets etc")]
    private bool canfire = true;

    private bool isReloading = false;
    public GameObject bullet;

    private PlayerCameraCon playerCamera;

    private void Start()
    {
        currentMag = (GameObject)Instantiate(currentMag, magPlace.transform);
        playerCamera = gameObject.GetComponentInParent<PlayerCameraCon>();
        animController = gameObject.GetComponent<Animator>();
    }

    public void SetVariables(int _magSize, int _bulletCount, float _damage, float _firerate, float _velocity, float _reloadspeed, bool _isSemi, bool _isBurst, float _Hrecoil, float _Vrecoil, float _maxSpread, int _burstCount)
    {
        magSize = _magSize;
        bulletCount = _bulletCount;
        damage = _damage;
        fireRate = _firerate;
        velocity = _velocity;
        reloadSpeed = _reloadspeed;
        isSemi = _isSemi;
        isBurst = _isBurst;
        Hrecoil = _Hrecoil;
        Vrecoil = _Vrecoil;
        maxSpread = _maxSpread;
        burstCount = _burstCount;
        if (isSemi == true && isBurst == true)
        {
            isSemiBurst = true;
        }
    }

    private void Update()
    {
        GetClickDown();

        if (currentAmmo >= magSize)
        {
            animController.SetBool("enableReload", false);
            StopCoroutine("Reload");
            animController.SetBool("enableReload", false);
        }
    }

    private void AttachmentUpdate()
    {
        // UpdateSights();

        //  UpdateMag();

        //  UpdateMuzzle();

        //  UpdateOther();
    }

    #region attachmentswitching ===========================================

    /*
    //======================================== god code
    private void UpdateMag()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (currentMag != null)
            {
                Destroy(currentMag);
            }
            currentMag = magObjs[indexMags].thisObj;
            currentMagScript = magObjs[indexMags];

            Debug.Log(indexMags);

            //  Instantiate(currentSight, sightPlace.transform.position, Quaternion.Euler(sightPlace.transform.forward));

            magSize = currentMagScript.magsize;

            currentAmmo = magSize;

            reloadSpeed = currentMagScript.reloadSpeed;
            indexMags++;
        }

        if (indexMags >= magObjs.Count)
        {
            indexMags = 0;
        }
    }

    //========================================

    private void UpdateSights()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (currentSight != null)
            {
                Destroy(currentSight);
            }
            currentSight = sightsObj[indexMags].thisObj;
            currentSightScript = sightsObj[indexMags];

            Debug.Log(indexSights);

            //  Instantiate(currentSight, sightPlace.transform.position, Quaternion.Euler(sightPlace.transform.forward));
            currentSight = (GameObject)Instantiate(currentSight, sightPlace.transform);

            indexSights++;
        }
        if (indexSights >= sightsObj.Count)
        {
            indexSights = 0;
        }
    }

    private void UpdateMuzzle()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (currentMuzzle != null)
            {
                Destroy(currentMuzzle);
            }
            currentMuzzle = muzzleObjs[indexMuzzles].thisObj;
            currentMuzzleScript = muzzleObjs[indexMuzzles];

            Debug.Log(indexMuzzles);

            //  Instantiate(currentSight, sightPlace.transform.position, Quaternion.Euler(sightPlace.transform.forward));
            currentMuzzle = (GameObject)Instantiate(currentMuzzle, muzzlePlace.transform);

            indexMuzzles++;
        }
        if (indexMuzzles >= muzzleObjs.Count)
        {
            indexMuzzles = 0;
        }
    }

    private void UpdateOther()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (currentOther != null)
            {
                Destroy(currentOther);
            }
            currentOther = otherObjs[indexOthers].thisObj;
            currentOtherScript = otherObjs[indexOthers];

            Debug.Log(indexOthers);

            //  Instantiate(currentSight, sightPlace.transform.position, Quaternion.Euler(sightPlace.transform.forward));
            currentOther = (GameObject)Instantiate(currentOther, muzzlePlace.transform);

            indexOthers++;
        }
        if (indexOthers >= otherObjs.Count)
        {
            indexOthers = 0;
        }
    }
    */

    #endregion attachmentswitching ===========================================

    private void GetClickDown()
    {
        if (currentAmmo <= 0)
        {
            StopCoroutine("AutoFire");
            StopCoroutine("BurstFire");
            canfire = false;
            if (isReloading != true)
            {
                animController.speed = 1 / reloadSpeed;
                animController.SetBool("enableReload", true);

                StartCoroutine(Reload());
            }

            return;
        }
        if (Input.GetMouseButton(0))
        {
            if (!canfire)
            {
                canfire = true;
                if (burstCount > 1)
                {
                    StartCoroutine("BurstFire");
                }
                else
                {
                    StartCoroutine("AutoFire");
                }
                canfire = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine("AutoFire");
            StopCoroutine("BurstFire");
            canfire = false;
        }
    }

    private void Shoot()
    {
        if (bulletCount > 1)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                FireSpread();
            }
        }
        else
        {
            Fire();
        }
        currentAmmo--;
    }

    private IEnumerator AutoFire()
    {
        while (canfire == true && !Input.GetMouseButtonUp(0))
        {
            Shoot();
            if (isSemi)
            {
                yield break;
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    private IEnumerator BurstFire()
    {
        while (canfire == true && !Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < burstCount; i++)
            {
                Shoot();
                yield return new WaitForSeconds(fireRate / (burstCount + 1));
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    private IEnumerator Reload()
    {
        while (currentAmmo <= 0)
        {
            //currentAmmo = 0;
            // reloadAnim.Play();
            animController.SetBool("enableReload", true);

            isReloading = true;
            yield return new WaitForSeconds(reloadSpeed);
            currentAmmo = magSize;
            isReloading = false;
            animController.SetBool("enableReload", false);
            StopCoroutine("AutoFire");
            StopCoroutine("BurstFire");
            yield break;
        }
    }

    private void FireSpread()
    {
        // fire() but with spread
        GameObject player = gameObject.GetComponentInParent<Transform>().gameObject;
        Quaternion spread = Quaternion.Euler(player.transform.rotation.eulerAngles + new Vector3(Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread), 0f));

        Vector3 muzzleoffset = muzzlePlace.transform.position;

        GameObject newBullet = Instantiate(bullet, muzzleoffset, spread) as GameObject;

        Bullet thisBullet = newBullet.GetComponent<Bullet>();
        thisBullet.BulletStats(damage);

        thisBullet.GetComponent<Rigidbody>().AddForce(thisBullet.transform.forward * (velocity * 5), ForceMode.Impulse);

        Recoil(Mathf.Sqrt(bulletCount + 2));
    }

    private void Fire()
    {
        GameObject player = gameObject.GetComponentInParent<Transform>().gameObject;
        Vector3 muzzleoffset = muzzlePlace.transform.position;

        GameObject newBullet = Instantiate(bullet, muzzleoffset, Quaternion.Euler(player.transform.rotation.eulerAngles)) as GameObject;

        Bullet thisBullet = newBullet.GetComponent<Bullet>();
        thisBullet.BulletStats(damage);

        thisBullet.GetComponent<Rigidbody>().AddForce(thisBullet.transform.forward * (velocity * 5), ForceMode.Impulse);

        Recoil(1);
    }

    private void Recoil(float amount)
    {
        float RndHrecoil = Random.Range(-Hrecoil, Hrecoil);
        playerCamera.Recoil(Vrecoil / amount, RndHrecoil);
    }
}