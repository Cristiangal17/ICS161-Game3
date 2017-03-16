using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two_CharacterMove : MonoBehaviour {


    public int jumpForce;
    public int walkForce;

    private bool isFacingForward;
    private bool hasSpeed;
    private float currSpeedTime;
    private float itemTime;
    private bool hasSlow;
    private float currSlowTime;
    private float currFreezeTime;
    

    // Use this for initialization
    void Start () {
        isFacingForward = true;
        itemTime = 4f;
        hasSpeed = false;
        hasSlow = false;
	}
	
	// Update is called once per frame
	void Update () {

        adjustPosition();

        if (GetComponent<PlayerCollectItem>().getFreeze())
        {
            if (currFreezeTime < (itemTime - 1))
                currFreezeTime += Time.deltaTime;
            else
            {
                currFreezeTime = 0;
                GetComponent<PlayerCollectItem>().setFreeze(false);
            }
            return;
        }
        if (hasSpeed)
        {
            if (currSpeedTime < itemTime)
                currSpeedTime += Time.deltaTime;
            else
                hasSpeed = false;
        }
        if (hasSlow)
        {
            if (currSlowTime < itemTime)
                currSlowTime += Time.deltaTime;
            else
                hasSlow = false;
        }


        if (Input.GetKey(KeyCode.S))
        {
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Crouch"))
            {
                GetComponent<Animator>().SetTrigger("CrouchTrigger");
            }
            transform.position += (transform.forward * (walkForce - walkForce / 3) * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
            transform.position += (transform.up * jumpForce * Time.deltaTime);
            GetComponent<Animator>().SetTrigger("FallTrigger");
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            if (!isFacingForward)
            {

                transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                isFacingForward = true;
            }
            walkPlayer(walkForce);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (isFacingForward)
            {
                transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                isFacingForward = false;
            }
            walkPlayer(walkForce);
        }
    }

    void walkPlayer(int speed)
    {
        
        if (hasSpeed)
        {
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                GetComponent<Animator>().SetTrigger("RunTrigger");
            }
            transform.position += (transform.forward * speed * 3 * Time.deltaTime);
        }
        else if (hasSlow)
        {
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SlowMo"))
            {
                GetComponent<Animator>().SetTrigger("SlowMoTrigger");
            }
            transform.position += (transform.forward * speed / 3 * Time.deltaTime);
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

    public void setCurrSpeedTime(int time)
    {
        currSpeedTime = time;
    }

    public void setHasSpeed(bool speed)
    {
        hasSpeed = speed;
    }
    public void setCurrSlowTime(int time)
    {
        currSlowTime = time;
    }

    public void setHasSlow(bool speed)
    {
        hasSlow = speed;
    }

    void adjustPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (isFacingForward)
        {
            transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }

    }


}
    
