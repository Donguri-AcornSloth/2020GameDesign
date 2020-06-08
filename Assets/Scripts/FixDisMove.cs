using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDisMove : MonoBehaviour
{

    public Vector3 moveX = new Vector3(1.0f, 0.0f, 0.0f);
    public Vector3 moveZ = new Vector3(0.0f, 0.0f, 1.0f);

    public float speed = 7.0f;
    public Vector3 logPos;
    Vector3 target;
    Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        target = transform.position;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;
        if (distance <= 0.0002f)
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));
            TargetPos();
        }
        Move();
    }

    void TargetPos()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position + moveX;
            return;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position - moveX;
            return;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position + moveZ;
            return;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            logPos = new Vector3(this.gameObject.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            target = transform.position - moveZ;
            return;
        }
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position,target,speed*Time.deltaTime);
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
