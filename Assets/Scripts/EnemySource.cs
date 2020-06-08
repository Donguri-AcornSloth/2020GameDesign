using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySource : MonoBehaviour
{
    public Vector3 moveX = new Vector3(1.0f, 0.0f, 0.0f);
    public Vector3 moveZ = new Vector3(0.0f, 0.0f, 1.0f);

    public GameObject Enemy;
    public GameObject Particle;
    public float speed = 7.0f;
    int time1;
    int time2;
    public int resetTime1 = 10;
    public int resetTime2 = 50;
    bool MovePatern;
    int MaxLimit = 4;
    int MinLimit = -4;
    public Vector3 target;
    ParticleSystem PS;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        MovePatern = true;
        time1 = resetTime1;
        time2 = resetTime2;
        PS = Particle.GetComponent<ParticleSystem>();
        Instantiate(Enemy, this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (transform.position - target).sqrMagnitude;
        if (distance <= 0.002f)
        {
            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z));

            time1 -= 1;
            time2 -= 1;
            if (time1 == 0)
            {
                if (MovePatern == true)
                {
                    target = target + moveX;
                    time1 = resetTime1;
                    if (target.x > MaxLimit)
                        MovePatern = false;
                }
                else if (MovePatern == false)
                {
                    target = target - moveX;
                    time1 = resetTime1;
                    if (target.x < MinLimit)
                        MovePatern = true;
                }
            }
            if (time2 == 0)
            {
                Transform Enetransform = this.gameObject.transform;
                Enetransform.parent = null;
                Instantiate(Particle, Enetransform.transform.position, Enetransform.transform.rotation, null);
                PS.Play();
                Instantiate(Enemy,Enetransform.position,Enetransform.rotation,null);
                time2 = resetTime2;
            }
        }
        Move();
    }
    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}
