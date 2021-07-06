using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public int magSize;
    private int currentAmmo;
    public float damage;
    public float fireRate;
    public float Maxrange;
    public float minRange;
    public float velocity;
    public float reloadSpeed;
    public bool isSemi;


    [Header("Attachment stuff")]
    public List<AttachmentScripts> sightsObj = new List<AttachmentScripts>();

    public List<AttachmentScripts> magObjs = new List<AttachmentScripts>();
    public List<AttachmentScripts> muzzleObjs = new List<AttachmentScripts>();
    public List<AttachmentScripts> otherObjs = new List<AttachmentScripts>();
    public GameObject sightPlace;
    public GameObject magPlace;
    public GameObject muzzlePlace;
    public GameObject otherPlace;
    private GameObject currentSight;
    private GameObject currentMag;
    private GameObject currentMuzzle;
    private GameObject currentOther;
    private AttachmentScripts currentSightScript, currentMagScript, currentMuzzleScript, currentOtherScript;

    private int indexSights;
    private int indexMags;
    private int indexMuzzles;
    private int indexOthers;

    [Header("other stuff, bullets etc")]
    private bool canfire = true;

    public GameObject bullet;

    // Update is called once per frame
    private void Update()
    {
        UpdateSights();

        UpdateMag();

        UpdateMuzzle();

        UpdateOther();

        GetClickDown();

        if (currentAmmo >= magSize)
        {
            StopCoroutine("Reload");
        }
    }

    #region attachmentswitching ===========================================

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
            currentMag = (GameObject)Instantiate(currentMag, magPlace.transform);

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

    #endregion attachmentswitching ===========================================

    private void GetClickDown()
    {
        if (currentAmmo <= 0)
        {
           StopCoroutine("AutoFire");
            canfire = false;
           if(currentMag != null)
            {
                StartCoroutine(Reload());
            }
           
            return;
        }
        if (Input.GetMouseButton(0))
        {
           

            if (!canfire)
            {
                canfire = true;
                StartCoroutine("AutoFire");
                canfire = true;
            }
          
        }
       
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine("AutoFire");
            canfire = false;
            
        }
    }

    private IEnumerator AutoFire()
    {
        while (canfire == true && !Input.GetMouseButtonUp(0))
        {
            Fire();
            currentAmmo--;
            if (currentAmmo > 0)
            {
                yield return new WaitForSeconds(fireRate);
            }
            if (isSemi)
            {
                yield break;

            }


        }
    }

    private IEnumerator Reload()
    {
        while (currentAmmo <= 0)
        {
            currentMag.SetActive(false);
            yield return new WaitForSeconds(reloadSpeed);
            currentMag.SetActive(true);
            currentAmmo = magSize;
        }
    }

    private void Fire()
    {
        GameObject player = gameObject.GetComponentInParent<Transform>().gameObject;
        Vector3 muzzleoffset = muzzlePlace.transform.position;
        GameObject newBullet = Instantiate(bullet, muzzleoffset, Quaternion.Euler(player.transform.rotation.eulerAngles)) as GameObject;
        Bullet thisBullet = newBullet.GetComponent<Bullet>();
        thisBullet.BulletStats(damage, velocity);
       
    }
}