using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public int maxPower;
    public int minPower;
    int Power;
    public bool kingSwitch;
    public GameObject resultText;
    public Judge eneJudge;
    public GameObject kingParticle;
    public GameObject normalParticle;
    ParticleSystem kingPS;
    ParticleSystem normalPS;
    AudioSource AS;
    public AudioClip normalDeth;
    public AudioClip kingDeth;
    // Start is called before the first frame update
    void Start()
    {
        minPower = 0;
        kingPS = kingParticle.GetComponent<ParticleSystem>();
        normalPS = normalParticle.GetComponent<ParticleSystem>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Power = Random.Range(minPower, maxPower);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("勝負！！");
        if (this.gameObject.tag == "Player" && other.gameObject.tag == "Enemy")
        {
            eneJudge = other.GetComponent<Judge>();
            if (Power >= eneJudge.Power) 
            {
                if(eneJudge.kingSwitch==true)
                {
                    resultText.SetActive(true);
                    Instantiate(kingParticle, other.gameObject.transform.position, other.gameObject.transform.rotation, null);
                    kingPS.Play();
                    AS.PlayOneShot(kingDeth);
                    minPower += 1;
                }
                else
                {
                    Instantiate(normalParticle, other.gameObject.transform.position, other.gameObject.transform.rotation, null);
                    normalPS.Play();
                    AS.PlayOneShot(normalDeth);
                    minPower += 1;
                }
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("負け");
            }
        }
        if (this.gameObject.tag == "Enemy" && other.gameObject.tag == "Player")
        {
            eneJudge = other.GetComponent<Judge>();
            if (Power >= eneJudge.Power)
            {
                if (eneJudge.kingSwitch == true)
                {
                    resultText.SetActive(true);
                    Instantiate(kingParticle, other.gameObject.transform.position, other.gameObject.transform.rotation, null);
                    kingPS.Play();
                    AS.PlayOneShot(kingDeth);
                    minPower += 1;
                }
                else
                {
                    Instantiate(normalParticle, other.gameObject.transform.position, other.gameObject.transform.rotation, null);
                    normalPS.Play();
                    AS.PlayOneShot(normalDeth);
                    minPower += 1;
                }
                other.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("負け");
            }
        }
    }
}
