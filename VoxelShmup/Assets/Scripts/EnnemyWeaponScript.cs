using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWeaponScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 20;
    public GameObject player;
    private Transform weapon;
    [SerializeField] private float cooldown = 5;
    private float timer = 0f;

    private void Start() {
        weapon = this.transform;
    }

    void Update()
    {
        Vector3 relativePos = player.transform.position - weapon.position;
        weapon.rotation = Quaternion.LookRotation(relativePos);
        if (timer < 0) {
            timer = cooldown;
            GameObject myBullet = Instantiate(bullet, weapon.position, weapon.rotation);
            myBullet.GetComponent<BulletScript>().speed = bulletSpeed;
            myBullet.GetComponent<BulletScript>().Setup(relativePos);
        }
        timer -= Time.deltaTime;
    }
}