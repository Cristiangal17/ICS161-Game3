using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public int jump;
    public int walk;

    private bool isFacingForward;

	// Use this for initialization
	void Start () {
        isFacingForward = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
            transform.position += (transform.up * jump * Time.deltaTime);
            GetComponent<Animator>().SetTrigger("FallTrigger");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                GetComponent<Animator>().SetTrigger("WalkTrigger");
            }
            if (!isFacingForward)
            {
                transform.Rotate(0, 180, 0);
                isFacingForward = true;
            }

            transform.position += (transform.forward * walk * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                GetComponent<Animator>().SetTrigger("WalkTrigger");
            }
            if (isFacingForward)
            {
                transform.Rotate(0, 180, 0);
                isFacingForward = false;
            }

            transform.position += (transform.forward * walk * Time.deltaTime);
        }

    }

}
