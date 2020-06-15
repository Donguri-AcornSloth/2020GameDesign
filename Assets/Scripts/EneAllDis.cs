using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneAllDis : MonoBehaviour
{ 
    public Vector3 [] posArray;
    int i = 0;

    float speed;
    public float chacespeed = 15.0f;
    public float patrollSpeed = 10.0f;
    public GameObject Player;
    Vector3 target;
    public Vector3 logPos;
    Rigidbody rigid;
    int resetTime = 50;
    public int ChaseTime = 25;
    public int patrollTime = 50;
    int time;
    public bool InArea;
    public bool trigger;
    Renderer Rend;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        target = GetComponent<Transform>().position;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        time = resetTime;
        Rend = GetComponent<Renderer>();
        Rend.material.color = Color.gray;
        Debug.Log(posArray.Length);
        i = Random.Range(0, posArray.Length - 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float pinDis = (posArray[i] - transform.position).sqrMagnitude; 
        if (pinDis <= 0.2f)
        {
            i = Random.Range(0, posArray.Length - 1);
        }
        float distance = (transform.position - target).sqrMagnitude;
        if (distance <= 0.002f)
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            time -= 1;
            if (time == 0)
            {
                Vector3 targetMag = posArray[i] - transform.position;
                logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                if (InArea == false)
                {
                    targetMag = posArray[i] - transform.position;
                    Rend.material.color = Color.green;
                    speed = patrollSpeed;
                    resetTime = patrollTime;
                }
                else if (InArea == true)
                {
                    targetMag = Player.transform.position - transform.position;
                    Rend.material.color = Color.red;
                    speed = chacespeed;
                    resetTime = ChaseTime;
                }
                if (targetMag.x > 0f)
                {
                    target.x = 1 + Mathf.CeilToInt(transform.position.x);
                }
                else if (targetMag.z > 0f)
                { 
                    target.z = 1 + Mathf.CeilToInt(transform.position.z);
                }
                else if (targetMag.x < 0f)
                {
                    target.x = -1 + Mathf.CeilToInt(transform.position.x);
                }
                else if (targetMag.z < 0f)
                {
                    target.z = -1 + Mathf.CeilToInt(transform.position.z);
                }
                else if (targetMag.x == 0f)
                {
                    target.x = Mathf.CeilToInt(transform.position.x);
                }
                else if (targetMag.z == 0f)
                {
                    target.z = Mathf.CeilToInt(transform.position.z);
                }
                time = resetTime;
            }

        }
        Move();
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            target = logPos;
            i = Random.Range(0, posArray.Length - 1);
        }
        Move();
    }
}
