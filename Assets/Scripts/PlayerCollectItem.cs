using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectItem : MonoBehaviour {
    private bool hasBolt= false;
    private bool hasNinjaSphere= false;
    private bool hasForceField= false;
    private bool hasSlowMo= false;
    private bool hasSwitch= false;
    private bool freeze = false;


    public Sprite spriteBolt;
    public Sprite spriteNinjaSphere;
    public Sprite spriteForceField;
    public Sprite noSprite;
    public Sprite spriteSlowMo;
    public Sprite spriteSwitch;

    public Image UI_image;

    
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "collectBolt")
        {
            hasBolt = true;
            hasNinjaSphere = false;
            hasForceField = false;
            hasSlowMo = false;
            hasSwitch = false;
            UI_image.sprite = spriteBolt;
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "collectNinjaSphere")
        {
            hasBolt = false;
            hasNinjaSphere = true;
            hasForceField = false;
            hasSlowMo = false;
            hasSwitch = false;
            UI_image.sprite = spriteNinjaSphere;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "collectForceField")
        {
            hasBolt = false;
            hasNinjaSphere = false;
            hasForceField = true;
            hasSlowMo = false;
            hasSwitch = false;
            UI_image.sprite = spriteForceField;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "collectSlowDown")
        {
            hasBolt = false;
            hasNinjaSphere = false;
            hasForceField = false;
            hasSlowMo = true;
            hasSwitch = false;
            UI_image.sprite = spriteSlowMo;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "collectSwitch")
        {
            hasBolt = false;
            hasNinjaSphere = false;
            hasForceField = false;
            hasSlowMo = false;
            hasSwitch = true;
            UI_image.sprite = spriteSwitch;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "NinjaSphere")
        {
            GetComponent<Animator>().SetTrigger("BallHitTrigger");
            freeze = true;
        }
    }

    public bool getFreeze()
    {
        return freeze;
    }
    public void setFreeze(bool yn)
    {
        freeze = yn;
    }

    public string checkInventory()
    {
        if (hasBolt)
            return "Bolt";
        if (hasForceField)
            return "ForceField";
        if (hasNinjaSphere)
            return "NinjaSphere";
        if (hasSlowMo)
            return "SlowMo";
        if (hasSwitch)
            return "Switch";
        return "None";
    }

    public void usedItem()
    {
        hasBolt = false;
        hasNinjaSphere = false;
        hasForceField = false;
        hasSlowMo = false;
        hasSwitch = false;
        UI_image.sprite = noSprite;
    }

}
