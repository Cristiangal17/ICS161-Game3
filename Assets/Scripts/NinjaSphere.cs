using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSphere : MonoBehaviour
{
    private bool shootActivate;
    void start()
    {
        shootActivate= false;
    }

    void Update()
    {
        if(shootActivate)
            transform.position += new Vector3(0.42f, 0, 0 );
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ForceField")
        {
            Destroy(gameObject);
        }
    }
    public void ActivateThrow()
    {
        shootActivate = true;
    }
}