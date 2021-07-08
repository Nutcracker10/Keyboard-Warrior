using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private Text scoreText;

    void Start() {
        scoreText = this.GetComponent<Text>();
        scoreText.text= "" + Typer.score;
    }

    void Update() {
        scoreText.text= "" + Typer.score;
    }
}
