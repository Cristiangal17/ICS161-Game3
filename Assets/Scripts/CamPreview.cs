using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamPreview : MonoBehaviour {

	void Update () {
		if(transform.position.x== 85)
            SceneManager.LoadScene("GameScene");
    }
}
