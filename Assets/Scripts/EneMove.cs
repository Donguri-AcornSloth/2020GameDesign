using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneMove : MonoBehaviour
{
    public int moveNum = 1;
    private int xNum;
    Vector3 moveX = new Vector3(1.0f, 0f, 0f);
    Vector3 moveZ = new Vector3(0f, 0f, 1.0f);
    private Vector3 moveDir;
    private int eDir;

    public float Speed = 7.0f;
    Vector3 target;
    Rigidbody rigid;
    public Vector3 logPos;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>().transform.position;
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;
        if (distance <= 0.002f)
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            TargetPosition();
        }
        Move();
    }
    void TargetPosition()
    {
        eDir = Random.Range(0, 2);
        if (eDir == 1)
        {
            moveDir = moveX;
        }
        else
        {
            moveDir = moveZ;
        }
        xNum = Random.Range(-1, 2);
        Debug.Log(xNum);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position + xNum * moveDir * moveNum;
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position + xNum * moveDir * moveNum;
            return;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position + xNum * moveDir * moveNum;
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position + xNum * moveDir * moveNum;
            return;
        }
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            target = logPos;
        }
        Move();
    }
}
