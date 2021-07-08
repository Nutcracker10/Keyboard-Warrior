using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    public void EndGame() {

        if (gameHasEnded == false) {
            gameHasEnded = true;
            Restart();
        }


        void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name );
        }
    }
}
