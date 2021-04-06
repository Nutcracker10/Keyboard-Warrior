using UnityEngine;
using UnityEngine.UI;

public class ShowMultiplier : MonoBehaviour
{
    public static int multiplier;
    private Text multText;

    void Start() {
        multText = this.GetComponent<Text>();
        multiplier = Typer.multiplier;
        multText.text = "x" + multiplier;
    }

    void Update() {
        multiplier = Typer.multiplier;
        multText.text= "x" + multiplier;
    }
}
