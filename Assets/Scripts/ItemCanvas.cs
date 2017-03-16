using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCanvas : MonoBehaviour {
    public GameObject nextItem;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Q))
        {
            nextItem.GetComponent<Animator>().SetTrigger("previewTrigger");
            gameObject.SetActive(false);
        }
    }
}
