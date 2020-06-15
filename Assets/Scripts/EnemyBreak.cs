using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBreak : MonoBehaviour
{
    MeshRenderer Rend;
    public GameObject Particle;
    ParticleSystem PS;
    public AudioSource Audio;
    bool deth;
    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<MeshRenderer>();
        PS = Particle.GetComponent<ParticleSystem>();
        Audio = GetComponent<AudioSource>();
        deth = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(deth==true)
        {
            if(Audio.isPlaying==false)
            {
                this.gameObject.SetActive(false);
            }
        }
 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")				
        {
            Rend.enabled = false;
            this.gameObject.GetComponent<EneRotDis>().enabled = false;
            Instantiate(Particle, this.gameObject.transform.position, this.gameObject.transform.rotation, null);
            PS.Play();
            Audio.Play();
            deth = true;
        }
    }
}
