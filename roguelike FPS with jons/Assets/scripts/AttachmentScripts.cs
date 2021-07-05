using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Attachment", menuName = "Guns/attachments")]
public class AttachmentScripts : ScriptableObject
{
    public GameObject thisObj;

    public bool isSigth, isMag, isMuzzle, isOther;


    [Header("is sight")]
    public float magnification;

    [Header("is a mag")]
    public int magsize;
    public float reloadSpeed;

    [Header("is a muzzle")]
    public float velocityIncrease;

    [Header("isOther")]
    public float hipfireMultiplier;


    


}
