using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSwitch : MonoBehaviour
{
    public GameObject Parlent;
    EneAllDis EAD;
    // Start is called before the first frame update
    void Start()
    {
        EAD = Parlent.GetComponent<EneAllDis>();
        
    }

    // Start is called On Trigger Object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EAD.InArea = true;        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EAD.InArea = false;
        }
    }
}
