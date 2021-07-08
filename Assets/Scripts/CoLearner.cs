using UnityEngine;
using UnityEngine.UI;

public class CoLearner : MonoBehaviour
{
    private Text message;
    private float time = 0f;
    private float displayTime = 3f;

    void Start()
    {
        message = GetComponent<Text>();
        message.text = "Type to Save the Castle!";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= displayTime) {
            SetBlank();
        }
    }

    void SetBlank() {
        message.text = "";
    }

    public void MadeMistake() {
        time = 0f;

        int choice = Random.Range(1,4);
        string text = "";

        switch(choice) {

            case 1:
                text = "Watch what you type!";
                break;
            
            case 2:
                text = "Wrong key friend!";
                break;
            
            case 3:
                text = "Slow down!";
                break;
        }

        message.text = text;
    }

    public void Compliment() {
        time = 0f;

        int choice = Random.Range(1,4);
        string text = "";

        switch(choice) {

            case 1:
                text = "You're doing great!!!";
                break;
            
            case 2:
                text = "Keep it up!";
                break;
            
            case 3:
                text = "Type like the wind!";
                break;
        }

        message.text = text;
    }

    public void TookDamage() {
        time = 0f;

        int choice = Random.Range(1,4);
        string text = "";

        switch(choice) {

            case 1:
                text = "They're getting in!!!";
                break;
            
            case 2:
                text = "The're breaking through!!!";
                break;
            
            case 3:
                text = "Cubes... CUBES EVERYWHERE!!!!";
                break;
        }

        message.text = text;
    }
}
