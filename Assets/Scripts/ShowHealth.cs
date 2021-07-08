using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealth : MonoBehaviour
{
    public static int health;
    private Text healthText;

    void Start() {
        healthText = this.GetComponent<Text>();
        healthText.text = "Health: " + Typer.health; 
    }

    void Update() {
        healthText.text = "Health: " + Typer.health;
    }
}
