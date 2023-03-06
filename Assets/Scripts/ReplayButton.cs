using UnityEngine;
using UnityEngine.SceneManagement;
public class ReplayButton : MonoBehaviour
{
    public void RestartGame()
    {
        Scene scene;
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
}
