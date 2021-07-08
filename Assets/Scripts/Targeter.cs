using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    public Typer typer;
    public Transform target;
    public float range = 100f;
    public string enemyTag="Enemy";
    public bool hasTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
            
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
            hasTarget = true;
            if (typer.GetCurrentWord() == "" || typer.GetCurrentWord() == null) {
                typer.SetCurrentWord();
            } 

            

        } else {
            target = null;
            hasTarget = false;
        }
    }

    void Update()
    {
        if (target == null) {
            typer.SetWordToBlank();
            return;
        } else if ( (typer.GetCurrentWord() == "") && hasTarget == true) {
            Debug.Log("Has Target");
            typer.SetCurrentWord();
        }

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
