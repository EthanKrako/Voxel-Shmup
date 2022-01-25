using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject bullet;
    private Transform weapon;
    [SerializeField] private float cooldown = 1f;
    private float timer = 0f;

    private void Start() {
        weapon = this.transform;
    }
    void Update()
    {
        if (timer < 0 && (Input.GetButton("Jump") || Input.GetButton("Fire1"))) {
            timer = cooldown;
            Instantiate(bullet, weapon.position, weapon.rotation);
        }
        timer -= Time.deltaTime;
    }
}
