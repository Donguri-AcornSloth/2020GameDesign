using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject Particle;
    ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = Particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")				 //　当たった相手のTagが”Wall”ならば・・
        {
            other.gameObject.SetActive(false);
            Instantiate(Particle, gameObject.transform.position, gameObject.transform.rotation, null);
            PS.Play();
            GameObject.Destroy(other.gameObject, 10.0f);			 //　Invoke（○○秒後に他のメソッドに飛ばす関数）、2秒後に「ObjActive」に飛びます
        }
    }
}
