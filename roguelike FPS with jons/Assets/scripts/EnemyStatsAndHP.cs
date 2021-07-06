using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsAndHP : MonoBehaviour
{


    public float maxHP;



    [Header("Misc options and HP bar")]
    public GameObject hpBar;
    public GameObject barScaling;
    public Color maxHPColor;
    public Color noHPColor;
    private Transform player;
    private float defaultScale;
    [HideInInspector]
    public float currentHP;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        defaultScale = barScaling.transform.localScale.y;
       // barHPMat = barScaling.GetComponent<Material>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
      
        hpBar.transform.LookAt(player);
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetHealthbarUi();

        }
    }
    private void SetHealthbarUi()
    {
        float healthPercentage = CalcHealth();
        float scaleAxis =  healthPercentage / 100 - 1;
        
        //Vector3 barSize = new Vector3(this.barScaling.transform.localScale.x,  , this.barScaling.transform.localScale.z);
         barScaling.GetComponent<Transform>().localScale += new Vector3(0, (barScaling.transform.localScale.y * defaultScale) / scaleAxis, 0);
     
    }


    private float CalcHealth()
    {
        return ((float)currentHP / (float)maxHP) * 100;
    }
}
