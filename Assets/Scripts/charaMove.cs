using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaMove : MonoBehaviour
{
    private CharacterController charaCon;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravity = -9.81f;
    private Animator animCon;

    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.0f;
    public float rotSpeed = 700f;

    // Start is called before the first frame update
    void Start()
    {
        charaCon = GetComponent<CharacterController>();
        animCon = GetComponent<Animator>();
        animCon.SetBool("Start", true);
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = charaCon.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charaCon.Move(dir * Time.deltaTime * playerSpeed);
        Debug.Log(dir);
        /*
        if (dir != Vector3.zero)
        {
            Quaternion qua = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qua, rotSpeed * Time.deltaTime);
            animCon.SetBool("Start", false);
        }
        else
        {
            animCon.SetBool("Start", true);
        }*/

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += jumpHeight * -1.0f * gravity;
            animCon.SetBool("Jump-01", true);
        }

        if(playerVelocity.y==0f)
        {
            animCon.SetBool("Jump-01", false);
        }
        playerVelocity.y += gravity * Time.deltaTime;
        charaCon.Move(playerVelocity * Time.deltaTime);     

    }
}