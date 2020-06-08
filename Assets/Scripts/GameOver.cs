using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject Particle;
    ParticleSystem PS;
    // Start is called before the first frame update
    public void Start()
    {
        PS = Particle.GetComponent<ParticleSystem>();
    }
    public void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            Player.gameObject.SetActive(false);
            Instantiate(Particle, Player.transform.position, Player.transform.rotation, null) ;
            PS.Play();
            Destroy(Player);
        }
    }
}
