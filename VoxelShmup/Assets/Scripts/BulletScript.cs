using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float lifetime = 2;
    
    void Start()
    {
        rb.velocity = Vector3.forward * speed;
    }

    private void FixedUpdate() {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) {
            Destroy(this.gameObject);
        }
    }
}
