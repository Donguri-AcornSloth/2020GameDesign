using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject Particle;
    public AudioSource destroyAudio;
    ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = Particle.GetComponent<ParticleSystem>();
        destroyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")				 //　当たった相手のTagが”Wall”ならば・・
        {
            this.gameObject.SetActive(false);
            Instantiate(Particle, this.gameObject.transform.position, this.gameObject.transform.rotation, null);
            PS.Play();
            destroyAudio.Play();
            //　Invoke（○○秒後に他のメソッドに飛ばす関数）、2秒後に「ObjActive」に飛びます
        }
    }
}
