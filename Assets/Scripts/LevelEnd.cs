using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public void seviye1end()
    {
        LevelController.seviye2 = true;
        SceneManager.LoadScene("seviye_2");
    }
    public void seviye2end()
    {
        LevelController.seviye3 = true;
        SceneManager.LoadScene("seviye_3");
    }
    public void seviye3end()
    {
        LevelController.seviye4 = true;
        SceneManager.LoadScene("seviye_4");
    }
    public void seviye4end()
    {
        LevelController.seviye5 = true;
        SceneManager.LoadScene("seviye_5");
    }
    public void seviye5end()
    {
        LevelController.seviye6 = true;
        SceneManager.LoadScene("seviye_6");
    }
    public void seviye6end()
    {
        LevelController.seviye7 = true;
        SceneManager.LoadScene("seviye_7");
    }
    public void seviye7end()
    {
        LevelController.seviye8 = true;
        SceneManager.LoadScene("seviye_8");
    }
    public void seviye8end()
    {
        LevelController.seviye9 = true;
        SceneManager.LoadScene("seviye_9");
    }
    public void seviye9end()
    {
        LevelController.seviye10 = true;
        SceneManager.LoadScene("seviye_10");
    }
    public void seviye10end()
    {
        LevelController.seviye11 = true;
        SceneManager.LoadScene("seviye_11");

    }
    public void seviye11end()
    {

        LevelController.seviye12 = true;
        SceneManager.LoadScene("seviye_12");
    }
    public void seviye12end()
    {
        LevelController.seviye13 = true;
        SceneManager.LoadScene("seviye_13");
    }
    public void seviye13end()
    {
        LevelController.seviye14 = true;
        SceneManager.LoadScene("seviye_14");
    }
    public void seviye14end()
    {
        SceneManager.LoadScene("seviye_15");
    }

}
