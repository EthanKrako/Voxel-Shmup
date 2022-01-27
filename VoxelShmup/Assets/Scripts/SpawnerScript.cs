using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
        SpawnEnemy();
    }

    private void Update() {
        if (GameObject.Find("Ennemy(Clone)") == null) {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        for (int i = -24; i <= 24; i += 6) {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(i, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            iTween.MoveTo(enemy, new Vector3(enemy.transform.position.x, enemy.transform.position.y, 13), 4);
        }
    }
}
