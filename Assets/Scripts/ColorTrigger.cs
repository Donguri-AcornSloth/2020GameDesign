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
    public int colorSwitch;
    public bool colisionSwitch;


    public AudioClip pClip;
    public AudioClip eClip;
    AudioSource Audio;
    
    // Start is called before the first frame update
    void Start()
    {
        mRend = GetComponent<MeshRenderer>();
        lTrigger = leftObj.GetComponent<ColorTrigger>();
        rTrigger = rightObj.GetComponent<ColorTrigger>();
        uTrigger = upObj.GetComponent<ColorTrigger>();
        dTrigger = downObj.GetComponent<ColorTrigger>();
        Audio = GetComponent<AudioSource>();
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
        if (colisionSwitch == true)
        {
            if (lTrigger.colorSwitch == rTrigger.colorSwitch)
            {
                if (lTrigger.colorSwitch > 0)
                {
                    colorSwitch = lTrigger.colorSwitch;
                    colisionSwitch = false;
                }
            }
            if (uTrigger.colorSwitch == dTrigger.colorSwitch)
            {
                if (uTrigger.colorSwitch > 0)
                {
                    colorSwitch = uTrigger.colorSwitch;
                    colisionSwitch = false;
                }
            }
            colisionSwitch = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag=="Player")
        {
            colorSwitch = 1;
            Audio.PlayOneShot(pClip);
            lTrigger.colisionSwitch = true;
            rTrigger.colisionSwitch = true;
            uTrigger.colisionSwitch = true;
            dTrigger.colisionSwitch = true;
        }
        if(other.gameObject.tag=="Enemy")
        {
            colorSwitch = 2;
            Audio.PlayOneShot(eClip);
            lTrigger.colisionSwitch = true;
            rTrigger.colisionSwitch = true;
            uTrigger.colisionSwitch = true;
            dTrigger.colisionSwitch = true;
        }
    }

}
