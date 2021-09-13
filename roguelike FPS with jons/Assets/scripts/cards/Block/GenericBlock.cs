using UnityEngine;

public class GenericBlock : MonoBehaviour
{
   // public GameObject colliderObj;

    private void Start()
    {
        GameObject player = GameObject.Find(StatCenter.playerName);
       // GameObject coll = Instantiate(colliderObj, player.transform) as GameObject;
        Debug.Log("block!!");
        

        Destroy(this.gameObject, 5f);
      //  Destroy(coll, 5f);
    }
}