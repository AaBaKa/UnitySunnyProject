
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;        //注：要转化，不然后面用vector3会报错


public class PlayControl : MonoBehaviour
{
    [Header("获取操作杆")] 
    public FloatingJoystick joystick;
    
    private Rigidbody2D rb;          
    private Animator anim;
    private float UpSpring = 700f;   //消灭敌人时弹跳
    private bool isHurt;

    // public AudioSource BGMAudio;
     public AudioSource jumpAudio;
     public AudioSource hurtAudio;
     public AudioSource gemAdudio;
     public AudioSource cherryAudio;
    // public AudioSource runAudio;
    
    public Collider2D coll;         //获取碰撞器
    public Collider2D DisColl;      //获得碰撞器
    
    public Transform downGround;   //检测地面
    public Transform CellingCeck;  //获取头顶，防止下蹲时头顶有遮挡物，依然能起立
    
    public float speed;             //速度，可以在外面编辑
    public float jumpforce;         //跳跃力
    public LayerMask ground;        //判断地面，可拖入 ，图层的意思
    public int cherry;              //果实收集数量
    public int gem;                 //宝石收集数量
    public int key;                 //钥匙收集数量
    public int orangeKey;          //橙色钥匙收集数量

    [Header("钥匙门")]
    public GameObject offDoor;       //关门的对象
    public GameObject onDoor;        //开门的对象
    public GameObject offDoorOrange;  //橙色钥匙才能开的门
    public GameObject onDoorOrange;   //橙色钥匙才能开的门
    
    [Header("文本")]
    public Text CherryNub;          //文本,显示樱桃收集的数量
    public Text GemNum;             //文本,显示宝石收集的数量
    public Text KeyNum;             //文本,显示钥匙收集的数量
    public Text orangeKeyNUm;       //文本,显示橙色钥匙收集的数量
    public Text OverPanelCherry;    //结束页面樱桃文本
    public Text OverPanelGem;       //结束页面宝石文本
    
    private bool isJump;            //是否能跳跃
    private bool isGround;          //是否在地面上
    private bool nearDoor;          //是否靠近门
    private bool nearDoorOrange;    //是否靠近橙色钥匙开的门
    private bool openDoor;          //是否能开门
    
    [Header("复活点")]
    public Vector2 RespawnPosition;

    [Header("是否死亡")] 
    public bool isDead;
    public bool overGameDoor;
    public bool goHome;

    [Header("头顶检测,地面检测参数")] 
    public float celling;
    public float downing;

    [Header("起跳次数")]
    public int jumpCount;

    [Header("开门按钮")] 
    public GameObject ButtonDoorOn;
    public GameObject ButtonDoorOnorange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<FloatingJoystick>();
        RespawnPosition = transform.position;
        
        //GameControl.instance.IsPlayer(this);
        //LevelManager.instance.player = this;
    }

    private void Update()
    {
        if (overGameDoor)
        {
            GameControl.instance.OverGameDoorPanel();
            //Time.timeScale = 0;
            return;
        }

        if (goHome)
        {
            GameControl.instance.GoHomePanel();
            return;
        }
        
        anim.SetBool("hurt",isDead);
        if (isDead)
        {
            Invoke("DestroyGameObject",0.5f);
            return;
        }
        
        WhetherJump();
        
        OnDoor();
        
    }
    
    void FixedUpdate()
    {
        OverPanelCherry.text = cherry.ToString();
        OverPanelGem.text = gem.ToString();
        if (overGameDoor || goHome)
        {
            return;
        }
        
        if (isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        IsGround(); //地面检测

        Movement(); //移动
        Jump();     //跳跃
        
        SwitchAnim();  //动画

        DoorUpFixEvent();
        DoorUpFixEventOrange();

    }

    #region 按键判断

    

    #endregion

    void Movement()
    {
        //键盘操作
        var horizontalmove = Input.GetAxisRaw("Horizontal");         //Input.GetAxis("Horizontal");获取-1到0,0到1之间

        //操纵杆操作
        //var horizontalmove = joystick.Horizontal;
        
        if (coll.enabled)
        {
            rb.velocity = new Vector2(horizontalmove * speed *0.5f, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);     //Vector2中的参数分别为，x轴与y轴的速度
        }
        
        //操纵杆操作
        if (horizontalmove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (horizontalmove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        //键盘操作
        //var facediretion = Input.GetAxisRaw("Horizontal");    //GetAxisRaw只获取-1,0,1,  左右翻转

        //PlayerMove移动
        if (horizontalmove != 0)        //即左右移动
        {
            anim.SetFloat("running",Mathf.Abs(horizontalmove));     //run动画播放
        }
        else
        {
            anim.SetFloat("running",-1);     //run动画播放
        }

        
        //键盘操作
        // if (facediretion != 0)
        // {
        //     transform.localScale = new Vector3(facediretion, 1, 1);
        // }
        
        Crouch();
    }

    //是否在地面
    void IsGround()
    {
        isGround = Physics2D.OverlapCircle(downGround.position, downing, ground);
        if (isGround)
        {
            rb.gravityScale = 1;    //刚体的重力属性
        }else
        {
            rb.gravityScale = 4;          //刚体的重力属性
        }
    }
    
    //PlayerJump跳跃
    void Jump()
    {
        if (!Physics2D.OverlapCircle(CellingCeck.position,celling,ground) && !anim.GetBool("crouch"))
        {
            if (isGround)         //如果在地面上，则起跳的次数为2
            {
                jumpCount = 2;
            }
        
            if (isJump && isGround)    //如果按下了起跳键，同时在地面上，也就是第一段跳
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);  //起跳
                jumpCount--;                                                            //起跳次数减一
                jumpAudio.Play();                                                       //播放起跳音段
                anim.SetBool("jumping",true);                                 //切换到起跳动作
                isJump = false;                                                         //退出的关键，不然会自动的一直跳
            }else if (isJump && !isGround && jumpCount > 0)     //如果按下了起跳键，同时在空中，起跳次数大于0
            {                                                   //（注：isGround为假时，是在空中，所以！isGround为真，执行该if语句）
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                jumpCount--;
                jumpAudio.Play();
                anim.SetBool("jumping",true);
                isJump = false;
            }
        }
    }

    //实现下降动画，和到地面后回到idel
    void SwitchAnim()
    {
        anim.SetBool("idel",false);
        
        // if (rb.velocity.y < 0 && !coll.IsTouchingLayers(ground))
        // {
        //     anim.SetBool("falling",true);
        // }
        
        if (anim.GetBool("jumping"))   //判断是否是跳跃状态，因为只有在跳跃状态才能才会有下落动画
        {
            if (rb.velocity.y < 0)          //即为下落状态
            {
                anim.SetBool("jumping",false);
                anim.SetBool("falling",true);
            }
        }
        else if (isHurt)
        {
            anim.SetBool("hurt",true);
            
            // anim.SetFloat("running",0);
            // if (Mathf.Abs(rb.velocity.x) < 0.1f)
            // {
            //     anim.SetBool("hurt",false);
            //     anim.SetBool("idel",true);
            //     isHurt = false;
            // }
        }
        else if (isGround)
        {
            anim.SetBool("falling",false);
            anim.SetBool("idel",true);
        }
    }

    //触发器检测
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collection")
        {
            cherryAudio.Play();
            cherry += 1;
            CherryNub.text = cherry.ToString();
        }

        if (other.tag == "宝石")
        {
            gemAdudio.Play();
            gem += 1;
            GemNum.text = gem.ToString();

        }

        if (other.tag == "钥匙")
        {
            gemAdudio.Play();
            key += 1;
            KeyNum.text = key.ToString();
        }

        if (other.tag == "橙色钥匙")
        {
            gemAdudio.Play();
            orangeKey += 1;
            orangeKeyNUm.text = orangeKey.ToString();

        }
        //消灭敌人触发器
        if (other.tag == "敌人")
        {
            Enemies enemies = other.gameObject.GetComponent<Enemies>();
            enemies.Jumpon();
            rb.velocity = new Vector2(rb.velocity.x, UpSpring * Time.deltaTime);
        }

        //掉落死亡线重新开始当前场景
        if (other.tag == "Deadline")
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restart",2f);
        }
        
        //是否靠近开门
        if (other.tag == "门")
        {
            nearDoor = true;
        }
        
        //是否靠近开门橙色钥匙
        if (other.tag == "门橙色")
        {
            nearDoorOrange = true;
        }


        if (other.tag == "火")
        {
            //BGMAudio.enabled = false;
            hurtAudio.Play();
            //isHurt = true;
            //GameControl.instance.ShowGameOverPanel();           //弹出死亡页面
            isDead = true;
            //Invoke("DestroyGameObject",1f);
        }

        if (other.CompareTag("复活点"))
        {
            RespawnPosition = other.transform.position;
        }

        if (other.CompareTag("结束门"))
        {
            overGameDoor = true;
        }

        if (other.CompareTag("家门"))
        {
            goHome = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //是否靠近开门
        if (other.tag == "门")
        {
            nearDoor = false;
        }
        
        //是否靠近开门橙色钥匙
        if (other.tag == "门橙色")
        {
            nearDoorOrange = false;
        }
    }

    //碰撞敌人后，后退
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "敌人")
        {
            if (transform.position.x < other.transform.position.x)
            {
                rb.velocity = new Vector2(rb.velocity.x - 10f, rb.velocity.y);
                //BGMAudio.enabled = false;
                hurtAudio.Play();
                isDead = true;
                

            }else if(transform.position.x > other.transform.position.x)
            {
                rb.velocity = new Vector2(rb.velocity.x + 10f, rb.velocity.y);
                //BGMAudio.enabled = false;
                hurtAudio.Play();
                isDead = true;
            }
        }
    }

    //下蹲
    void Crouch()
    {
        if (!Physics2D.OverlapCircle(CellingCeck.position,celling,ground))
        {
            if (Input.GetButton("Crouch") || PlayerCrouch.instance.isCrouch && isGround)
            {
                anim.SetBool("crouch", true);
                coll.enabled = true;
                DisColl.enabled = false;
            }
            else
            {
                anim.SetBool("crouch", false);
                coll.enabled = false;
                DisColl.enabled = true;
            }
        }
    }

    void DestroyGameObject()
    {
        //Destroy(gameObject);  //销毁对象
        GameControl.instance.ShowGameOverPanel();           //弹出死亡页面
        gameObject.SetActive(false);
    }

    //重新加载当前场景
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //是否按下起跳键
    void WhetherJump()    //键盘操作
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJump = true;
        }
    }
    
    //按钮操作,事件
    public void ButtonJump()   
    {
        if (jumpCount > 0)
        {
            isJump = true;
        }
        
    }

    

    #region 钥匙开门
    
    //开门操作
    void OnDoor()
    {
        if (nearDoor)
        {
            if (key > 0 && Input.GetKeyDown(KeyCode.E) )
            {
                offDoor.SetActive(false);
                onDoor.SetActive(true);
            }

            if (orangeKey > 0 && Input.GetKeyDown(KeyCode.E))
            {
                offDoorOrange.SetActive(false);
                onDoorOrange.SetActive(true);
            }
            
        }
    }

    private void DoorUpFixEvent()   //按钮出现判断
    {
        if (nearDoor && offDoor)
        {
            ButtonDoorOn.SetActive(true);
        }
        else
        {
            ButtonDoorOn.SetActive(false);
        }
    }

    public void DoorUpButton()  //开门按钮事件
    {
        if (key > 0)
        {
            offDoor.SetActive(false);
            onDoor.SetActive(true);
        }
    }
    
    private void DoorUpFixEventOrange()   //橙色钥匙按钮出现判断
    {
        if (nearDoorOrange && offDoorOrange)
        {
            ButtonDoorOnorange.SetActive(true);
        }
        else
        {
            ButtonDoorOnorange.SetActive(false);
        }
    }
    
    public void DoorUpButtonOrange()  //黄色钥匙开门按钮事件
    {
        if (orangeKey > 0)
        {
            offDoorOrange.SetActive(false);
            onDoorOrange.SetActive(true);
        }
    }

    #endregion
    
    
    //画出区域
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(CellingCeck.position,celling);
        Gizmos.DrawWireSphere(downGround.position, downing);
    }

    
}
