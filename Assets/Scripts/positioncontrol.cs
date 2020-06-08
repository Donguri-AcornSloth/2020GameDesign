using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positioncontrol : MonoBehaviour
{
    public GameObject targetObj;
    Transform TR;
    Transform targetTR;
    // Start is called before the first frame update
    void Start()
    {
        TR = GetComponent<Transform>();
        targetTR = targetObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetTR.position;
    }
}
