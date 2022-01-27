using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWeaponScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 20;
    private GameObject player;
    private Transform weapon;
    [SerializeField] private float cooldown = 5;
    private float timer = 0f;

    private void Start() {
        weapon = this.transform;
        player = GameObject.FindGameObjectWithTag("Player");
        timer = 5;
    }

    void Update()
    {
        if (GameObject.Find("Spaceship") != null) {
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
}