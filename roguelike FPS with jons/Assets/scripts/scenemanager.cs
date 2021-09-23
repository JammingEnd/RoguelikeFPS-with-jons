using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  Cursor.lockState = CursorLockMode.Locked;
        Physics.IgnoreLayerCollision(7, 7, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
