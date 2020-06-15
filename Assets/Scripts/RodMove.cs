﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodMove : MonoBehaviour
{
    Vector3 rotPoint = Vector3.zero;
    Vector3 rotAxis = Vector3.zero;
    public float rotNum = 8f;
    float rotAngle;

    float halfCube;
    public bool inRotate = false;
    Vector3 logPos;
    // Start is called before the first frame update
    void Start()
    {
        halfCube = transform.localScale.x / 2f;
        rotAngle = rotNum;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        if (inRotate)
            return;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotPoint = transform.position + new Vector3(halfCube, -halfCube, 0f);
            rotAxis = new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            rotPoint = transform.position + new Vector3(-halfCube, -halfCube, 0f);
            rotAxis = new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotPoint = transform.position + new Vector3(0f, -halfCube, halfCube);
            rotAxis = new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotPoint = transform.position + new Vector3(0f, -halfCube, -halfCube);
            rotAxis = new Vector3(-1, 0, 0);
        }
        if (rotPoint == Vector3.zero)
            return;
        StartCoroutine(MoveCube());

    }
    IEnumerator MoveCube()
    {
        inRotate = true;
        float angle = 0f;
        while(angle<90f)
        {
            angle += rotAngle;
            if(angle>90f)
            {
                rotAngle -= angle - 90f;
            }
            transform.RotateAround(rotPoint, rotAxis, rotAngle);
            rotAngle = rotNum;
            yield return null;
        }
        inRotate = false;
        rotPoint = Vector3.zero;
        rotAxis = Vector3.zero;
        yield break;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            rotPoint = logPos;
        }
    }
}
