using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneRotDis : MonoBehaviour
{
    public Vector3[] posArray;
    int i = 0;
    Rigidbody rigid;
    public int time ;
    public int resettime;
    public int patrolltime;
    public GameObject Player;
    public int chasetime;
    public bool InArea;
    public Vector3 logPos;
    public bool chaceMode;
    Vector3 rotPoint = Vector3.zero;
    Vector3 rotAxis = Vector3.zero;
    float rotNum;
    public float rotNumChase;
    public float rotNumPatroll;
    float rotAngle;
    float halfCube;
    bool inRotate;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        halfCube = transform.localScale.x / 2f;
        rotNum = rotNumPatroll;
        rotAngle = rotNum;
        resettime = patrolltime;
        time = resettime;
        i = Random.Range(0, posArray.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRotate == true)
        {
            return;
        }
        float pinDis = (posArray[i] - transform.position).sqrMagnitude;
        if(pinDis<=0.2f)
        {
            i = Random.Range(0, posArray.Length);
            Debug.Log(i);
            if (i == posArray.Length) 
            {
                Debug.LogError("IDFailed");
                i = Random.Range(0, posArray.Length);
            }
        }
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
        time -= 1;
        if (time == 0)
        {
            Vector3 targetMag = posArray[i] - transform.position;
            logPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            if (InArea == false)
            {
                targetMag = posArray[i] - transform.position;
                rotNum = rotNumPatroll;
                resettime = patrolltime;
            }
            else if (InArea == true)
            {
                if (chaceMode == true)
                {
                    targetMag = transform.position - Player.transform.position;
                    rotNum = rotNumPatroll;
                    resettime = chasetime;
                }
            }
            if (targetMag.x > 0f)
            {
                rotPoint = transform.position + new Vector3(halfCube, -halfCube, 0f);
                rotAxis = new Vector3(0, 0, -1);
            }
            else if (targetMag.z > 0f)
            {
                rotPoint = transform.position + new Vector3(0f, -halfCube, halfCube);
                rotAxis = new Vector3(1, 0, 0);
            }
            else if (targetMag.x < 0f)
            {
                rotPoint = transform.position + new Vector3(-halfCube, -halfCube, 0f);
                rotAxis = new Vector3(0, 0, 1);
            }
            else if (targetMag.z < 0f)
            {
                rotPoint = transform.position + new Vector3(0f, -halfCube, -halfCube);
                rotAxis = new Vector3(-1, 0, 0);
            }
            time = resettime;
            StartCoroutine(MoveCube());
        }
        IEnumerator MoveCube()
        {
            inRotate = true;
            float angle = 0f;
            while (angle < 90f)
            {
                angle += rotAngle;
                if (angle > 90f)
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            rotPoint = logPos;
            i = Random.Range(0, posArray.Length - 1);
        }
    }
}
