
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    private PlayControl player;    
    
    [Header("死亡页面")]
    public GameObject gameOverPanel;     //死亡页面
    [Header("结束进门页面")]
    public GameObject overDoorPanel;    //结束进门页面
    [Header("家门页面")] 
    public GameObject goHomePanel;

    [Header("终点门碰撞器")]
    public Collider2D doorColl;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        overDoorPanel.SetActive(false);
        goHomePanel.SetActive(false);
        player = FindObjectOfType<PlayControl>();
    }

    public void IsPlayer(PlayControl playControl)
    {
        player = playControl;
    }

    //弹出死亡页面
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    
    //弹出结束页面
    public void OverGameDoorPanel()
    {
        overDoorPanel.SetActive(true);
    }

    //弹出家门页面
    public void GoHomePanel()
    {
        goHomePanel.SetActive(true);
    }

    //重新加载当前场景
    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.isDead = false;
        player.transform.position = player.RespawnPosition;
        player.GetComponent<Animator>().SetBool("hurt",false);
        player.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        
    }

    //继续下一关卡按钮事件
    public void ContinueButton()
    {
        SceneManager.LoadScene("Scenes011");
    }
    
    //返回首页按钮事件
    public void ReHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
