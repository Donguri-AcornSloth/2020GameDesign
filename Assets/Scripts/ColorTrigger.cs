using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    public GameObject leftObj;
    ColorTrigger lTrigger;
    public GameObject rightObj;
    ColorTrigger rTrigger;
    public GameObject upObj;
    ColorTrigger uTrigger;
    public GameObject downObj;
    ColorTrigger dTrigger;

    GameObject thisPanel;
    MeshRenderer mRend;
    int colorSwitch;
    
    // Start is called before the first frame update
    void Start()
    {
        mRend = GetComponent<MeshRenderer>();
        lTrigger = leftObj.GetComponent<ColorTrigger>();
        rTrigger = rightObj.GetComponent<ColorTrigger>();
        uTrigger = upObj.GetComponent<ColorTrigger>();
        dTrigger = downObj.GetComponent<ColorTrigger>();
        thisPanel = this.gameObject;
        mRend.enabled = false; 
        colorSwitch = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(colorSwitch>0)
        {
            mRend.enabled = true;
            if (colorSwitch == 1)
            {
                mRend.material.color = Color.white;
                thisPanel.tag = "PlayerPanel";
            }
            else if(colorSwitch==2)
            {
                mRend.material.color = Color.black;
                thisPanel.tag = "EnemyPanel";
            }
        }
        if(lTrigger.colorSwitch==rTrigger.colorSwitch)
        {
            if (lTrigger.colorSwitch > 0)
            {
                colorSwitch = lTrigger.colorSwitch;
            }
        }
        if(uTrigger.colorSwitch==dTrigger.colorSwitch)
        {
            if(uTrigger.colorSwitch>0)
            {
                colorSwitch = uTrigger.colorSwitch;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            colorSwitch = 1;
        }
        if(other.gameObject.tag=="Enemy")
        {
            colorSwitch = 2;
        }
    }

}
