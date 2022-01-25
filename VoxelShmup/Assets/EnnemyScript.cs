using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    private Transform weapon;
    [SerializeField] private float cooldown = 1f;
    private float timer = 0f;

    private void Start() {
        weapon = this.transform;
    }

    void Update()
    {
        if (timer < 0) {
            timer = cooldown;
            Instantiate(bullet, weapon.position, weapon.rotation);
        }
        timer -= Time.deltaTime;
    }
}
