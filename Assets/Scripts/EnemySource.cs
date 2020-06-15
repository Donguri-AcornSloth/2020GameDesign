using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySource : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Particle;
    public float speed = 7.0f;
    int time;
    public int resetTime = 50;
    public Vector3 target;
    ParticleSystem PS;

    // Start is called before the first frame update
    void Start()
    {
        time = resetTime;
        PS = Particle.GetComponent<ParticleSystem>();
        Instantiate(Enemy, this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= 1;

        if (time == 0)
        {
        Transform Enetransform = this.gameObject.transform;
        Enetransform.parent = null;
        Instantiate(Particle, Enetransform.transform.position, Enetransform.transform.rotation, null);
        PS.Play();
        Instantiate(Enemy,Enetransform.position,Enetransform.rotation,null);
        time = resetTime;
        }

    }

}
