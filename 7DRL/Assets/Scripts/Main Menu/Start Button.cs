using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TrainingTestScene");
    }
}
