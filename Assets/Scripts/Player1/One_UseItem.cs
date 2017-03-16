using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class One_UseItem : MonoBehaviour
{
    public GameObject forcefield;
    public GameObject shell;
    public GameObject enemy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string item = GetComponent<PlayerCollectItem>().checkInventory();

            if (item == "Bolt")
            {
                GetComponent<One_CharacterMove>().setCurrSpeedTime(0);
                GetComponent<One_CharacterMove>().setHasSpeed(true);
                GetComponent<PlayerCollectItem>().usedItem();
            }
            else if (item == "ForceField")
            {
                GetComponent<PlayerCollectItem>().usedItem();
                GameObject bubble = Instantiate(forcefield, transform.position, transform.rotation);
                bubble.transform.parent = transform;

            }
            else if (item == "NinjaSphere")
            {
                GetComponent<Animator>().SetTrigger("ThrowTrigger");
                GetComponent<PlayerCollectItem>().usedItem();
                GameObject throwing = Instantiate(shell, (transform.position + new Vector3(1, 0, 0)), transform.rotation);
                throwing.GetComponent<NinjaSphere>().ActivateThrow();
            }

            else if (item == "SlowMo")
            {
                enemy.GetComponent<Two_CharacterMove>().setCurrSlowTime(0);
                enemy.GetComponent<Two_CharacterMove>().setHasSlow(true);
                GetComponent<PlayerCollectItem>().usedItem();

            }
            else if (item == "Switch")
            {
                GetComponent<Animator>().SetTrigger("SwitchTrigger");
                enemy.GetComponent<Animator>().SetTrigger("SwitchTrigger");
                Vector3 tempPosition;
                tempPosition = transform.position;
                transform.position = enemy.transform.position;
                enemy.transform.position = tempPosition;
                GetComponent<PlayerCollectItem>().usedItem();
            }


        }

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "WinPlatform")
        {
            enemy.SetActive(false);
            SceneManager.LoadScene("WinP1");
        }
    }
}
