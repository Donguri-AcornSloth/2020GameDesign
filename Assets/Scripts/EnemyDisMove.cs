using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisMove : MonoBehaviour
{
    public Vector3 moveX = new Vector3(1.0f, 0.0f, 0.0f);
    public Vector3 moveZ = new Vector3(0.0f, 0.0f, 1.0f);

    public float speed = 7.0f;
    public GameObject Particle;
    Vector3 target;
    Rigidbody rigid;
    public int time;
    Vector3 origPos;
    public int resetTime = 50;
    ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        target = transform.position;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        origPos = transform.position;
        time = resetTime;
        PS = Particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;  		// どのくらい近づいたかを距離で判定
        if (distance <= 0.002f)                      				//　もし距離が0.002（０に近ければ任意の数字でOK）よりも近ければ・・
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.RoundToInt(transform.position.z));　 //　Z位置の値を整数にします
            time -= 1;					 //　変数Timeの値から1を引きます
            if (time <= 0)					 //　もしTimeの値が０ならば・・・ 	
            {
                target = target - moveZ;				 //　targetの値から、変数moveZに入れられたpositionを引きます
                time = resetTime;					 //　timeにresetTime値を入れてタイマーを元に戻します
            }
        }
        Move();
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
    //　Move（）メソッドに移動します

    void OnTriggerEnter(Collider other)				 //　OnTriggerEnter（）メソッド	
    {
        if (other.gameObject.tag == "Player")				 //　当たった相手のTagが”Wall”ならば・・
        {
            gameObject.SetActive(false);
            Instantiate(Particle, gameObject.transform.position, gameObject.transform.rotation, null);
            PS.Play();
            GameObject.Destroy(this.gameObject,10.0f);			 //　Invoke（○○秒後に他のメソッドに飛ばす関数）、2秒後に「ObjActive」に飛びます
        }
    }


}


