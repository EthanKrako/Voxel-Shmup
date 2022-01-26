using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private ParticleSystem explosion;
    private float timer = 0f;

    private void Update() {
        if (health < 1) {
            Explode();
        }
    }

    private void OnTriggerEnter(Collider other) {
        health -= 1;
    }

    private void Explode() {
        Instantiate(explosion, this.gameObject.transform.position, new Quaternion(0,0,0,0));
        Destroy(this.gameObject);
    }
}
