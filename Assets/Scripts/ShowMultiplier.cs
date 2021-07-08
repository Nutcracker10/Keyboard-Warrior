using UnityEngine;
using UnityEngine.UI;

public class ShowMultiplier : MonoBehaviour
{
    private Text multText;

    void Start() {
        multText = this.GetComponent<Text>();
        multText.text = "x" + Typer.multiplier;
    }

    void Update() {
        multText.text= "x" + Typer.multiplier;
    }
}
