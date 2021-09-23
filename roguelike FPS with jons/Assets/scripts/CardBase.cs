using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class CardBase : ScriptableObject
{


    public string cardName;

    public GameObject behaviourScript;
    public string behaviourName;

    public bool isNoDuplicateCard;
    public bool isBlockCard;
    public List<string> variableName = new List<string>();
    public List<float> modifiers = new List<float>();

    public int rarity;
    
    private StatCenter statCenter;
    // Start is called before the first frame update
    private void Awake()
    {
        
        
    }
    public void SelectCard(StatCenter _statCenter)
    {
        statCenter = _statCenter;

    }
    public void GetScriptName()
    {
       // behaviourName = behaviourScript.ToString();
    }
    
    public void SetVariablesForStatCenter()
    {
        for (int i = 0; i < variableName.Count; i++)
        {
            statCenter.SetVariablesFromCard(variableName[i], modifiers[i]);
        }
        
        
        
    }
    //if it has special abilities
    public void ActivateAbility()
    {
        if(behaviourScript != null)
        {
            
            
        }
    }


}
