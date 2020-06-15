using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSwitch2 : MonoBehaviour
{
    public GameObject Parlent;
    EneRotDis ERD;
    // Start is called before the first frame update
    void Start()
    {
        ERD = Parlent.GetComponent<EneRotDis>();
    }

    private void Update()
    {
        if (Parlent.activeSelf == false)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            ERD.Player = other.gameObject;
            ERD.InArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            ERD.InArea = false;
        }
    }
}
