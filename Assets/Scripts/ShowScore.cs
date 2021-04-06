using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public static int score;
    private Text scoreText;

    void Start() {
        scoreText = this.GetComponent<Text>();
        score = Typer.score;
        scoreText.text= "" + score;
    }

    void Update() {
        score = Typer.score;
        scoreText.text= "" + score;
    }
}
