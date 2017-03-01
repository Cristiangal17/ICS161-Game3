using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterMove : NetworkBehaviour {


    public int jumpForce;
    public int walkForce;

	[SyncVar]
	public string playerName = "player";

	[SyncVar]
	public Color playerColor = Color.white;




    private bool isFacingForward;
    private bool hasSpeed;
    private float currSpeedTime;
    private float itemTime;


	// Use this for initialization
	void Start () {
        isFacingForward = true;
        itemTime = 2f;
        hasSpeed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (hasSpeed)
        {
            if (currSpeedTime < itemTime)
                currSpeedTime += Time.deltaTime;
            else
                hasSpeed = false;
        }





        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
            transform.position += (transform.up * jumpForce * Time.deltaTime);
            GetComponent<Animator>().SetTrigger("FallTrigger");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!isFacingForward)
            {
                transform.Rotate(0, 180, 0);
                isFacingForward = true;
            }
            walkPlayer(walkForce);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (isFacingForward)
            {
                transform.Rotate(0, 180, 0);
                isFacingForward = false;
            }
            walkPlayer(walkForce);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bolt")
        {
            currSpeedTime = 0;
            Destroy(col.gameObject);
            hasSpeed = true;
        }
    }

    void walkPlayer(int speed)
    {
        if (hasSpeed)
        {
            transform.position += (transform.forward * speed * 10 * Time.deltaTime);
        }
        else
        {
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                GetComponent<Animator>().SetTrigger("WalkTrigger");
            }
            transform.position += (transform.forward * speed * Time.deltaTime);
        }
    }



}
    
