using UnityEngine;
using System.Collections.Generic;

public class LightningSpawn : MonoBehaviour
{
    public Targeter targeter;
    private LineRenderer lr;
    private new AudioSource audio;

    private float displayTime = 0.1f;
    private float timer;

    public void Awake() {
        lr = GetComponent<LineRenderer>();
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        timer += Time.deltaTime;

        if (timer >= displayTime) {
            DisableEffects();
        }
    }

    public void DisableEffects() {
        lr.enabled = false;
    }

    public void Fire() {
        
        timer = 0f;
        
        RaycastHit hit;

        Vector3 fromPos = transform.position;
        Vector3 toPos = targeter.target.position;
        Vector3 direction = toPos - fromPos;

        lr.enabled = true;
        lr.SetPosition(0, transform.position);

        audio.Play();

        if (Physics.Raycast(transform.position, direction, out hit) ) {

            lr.SetPosition(1, hit.point);

            Destroy(hit.transform.gameObject);
        }

    }
}
