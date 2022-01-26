using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private int speed = 30;
    [SerializeField] private float immunity = 1;
    public int health = 3;
    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (health < 1) {
            rb.velocity = new Vector3(0, 0, 0);
            this.enabled = false;
        }
        immunity -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (immunity < 0)
        health -= 1;
        immunity = 1;
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(horizontal, 0, vertical).normalized * speed;
        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0,180,horizontal * 20), Time.deltaTime * 5);
    }
}
