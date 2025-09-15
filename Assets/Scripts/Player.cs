using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 5f;

    Vector3 input = Vector3.zero;

    [SerializeField] Rigidbody rb;

    [SerializeField] GroundSensor ground;

    float velY;

    [SerializeField] LayerMask myLayer;
    [SerializeField] LayerMask obstacles;

    [SerializeField] Animator myController;
    [SerializeField] AnimEvent events;

    [SerializeField] GameObject attck_01;  

    private void Start()
    {
        events.Subscribe("canMove", CanMove);
        events.Subscribe("begin_attack", Begin_Attack);
        events.Subscribe("end_attack", End_Attack);

        attck_01.SetActive(false);
    }

    void Begin_Attack()
    {
        attck_01.SetActive(true);
    }
    void End_Attack()
    {
        attck_01.SetActive(false);
    }

    void CanMove()
    {
        isAttacking = false;
        myController.SetBool("isAttacking", false);
    }

    bool isAttacking = false;

    float originalMagnitude;

    void Update()
    {
        if (isAttacking) return;

        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        originalMagnitude = input.magnitude;
        myController.SetFloat("movMagnitud", originalMagnitude);

        myController.SetFloat("movX", input.x);
        myController.SetFloat("movY", input.z);

        input.Normalize();

        velY = rb.velocity.y;


        if (Input.GetButtonDown("Fire1"))
        {
            myController.SetBool("isAttacking", true);
            isAttacking = true;
        }


        if (Input.GetButtonDown("Jump") && ground.IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, myLayer)) // floor, obstacle
        {
            if ((obstacles & 1 << hit.collider.gameObject.layer) != 0)
            {
                // Obstacle
            }
        }
    }

    Vector3 move;
    private void FixedUpdate()
    {
        if (isAttacking) return;
        //move = input * speed * Time.fixedDeltaTime;
        //rb.velocity = new Vector3(move.x, velY, move.z);
        rb.MovePosition(transform.position + input * originalMagnitude * speed * Time.fixedDeltaTime);
    }
}
