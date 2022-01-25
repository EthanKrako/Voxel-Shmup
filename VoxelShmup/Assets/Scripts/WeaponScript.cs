using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject bullet;
    private Transform weapon;
    public float bulletSpeed = 30;
    [SerializeField] private float cooldown = 1f;
    private float timer = 0f;

    private void Start() {
        weapon = this.transform;
    }
    void Update()
    {
        if (timer < 0 && (Input.GetButton("Jump") || Input.GetButton("Fire1"))) {
            timer = cooldown;
            GameObject myBullet = Instantiate(bullet, weapon.position, weapon.rotation);
            myBullet.GetComponent<BulletScript>().speed = bulletSpeed;
            myBullet.GetComponent<BulletScript>().Setup(Vector3.forward);
        }
        timer -= Time.deltaTime;
    }
}
