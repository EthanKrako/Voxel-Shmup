using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 30f;
    [SerializeField] private float lifetime = 2;
    private Vector3 shootDir;
    [SerializeField] private ParticleSystem explosion;
    
    void Start()
    {
        rb.velocity = shootDir.normalized * speed;
    }

    public void Setup(Vector3 dir) {
        shootDir = dir;
    }

    private void FixedUpdate() {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) {
            Explode();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ennemy") {
            Explode();
        }
    }

    private void Explode() {
        Instantiate(explosion, rb.position, rb.rotation);
        Destroy(this.gameObject);
    }
}
