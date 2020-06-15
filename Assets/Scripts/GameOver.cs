using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject Particle;
    public AudioSource Audio;
    MeshRenderer Rend;
    ParticleSystem PS;
    bool deth;
    // Start is called before the first frame update
    public void Start()
    {
        PS = Particle.GetComponent<ParticleSystem>();
        Audio.GetComponent<AudioSource>();
        Rend = Player.GetComponent<MeshRenderer>();
        deth = false;
    }
    public void Update()
    {
        if (deth == true)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            Rend.enabled = false;
            Player.gameObject.GetComponent<RodMove>().enabled = false;
            Player.gameObject.GetComponent<BoxCollider>().enabled = false;
            Instantiate(Particle, Player.gameObject.transform.position, Player.gameObject.transform.rotation, null);
            PS.Play();
            Audio.Play();
            deth = true;
        }
    }
}
