
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //简单模式按钮
    public void SimpleGame()
    {
        SceneManager.LoadScene("Scenes02");
    }
    
    //困难模式
    public void HardGame()
    {
        SceneManager.LoadScene("Scenes03");
    }

    //退出按钮
    public void QuitGame()
    {
        Application.Quit();     
    }
}
