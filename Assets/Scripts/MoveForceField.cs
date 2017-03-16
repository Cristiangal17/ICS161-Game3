using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForceField : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "NinjaSphere" )
        {
            Destroy(gameObject);
        }
    }
}
    
