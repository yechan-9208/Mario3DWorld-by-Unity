using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public GameObject gameStartUI;
    public GameObject gamingUI;
    public GameObject gameEndUI;
    public GameObject bigMairo;
    public GameObject smallMario;
    public GameObject currentMario;
    public Transform spwanPosion;
    public Transform startPosition;
    public Transform endPosition;

    public Animator anim;


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool isInvincible = false;
    float invincibleDuration = 2f;
    float originalAlpha;
    Renderer playerRenderer;

    public void BigToSmallMario()
    {
        smallMario.transform.position = bigMairo.transform.position;
        bigMairo.SetActive(false);
          


        StartCoroutine(MyCoroutine());
    }

    public void gameOver()
    {
        smallMario.SetActive(false);
        bigMairo.transform.position = spwanPosion.transform.position;
        bigMairo.SetActive(true);
        currentMario = bigMairo;
    }



    private IEnumerator MyCoroutine()
    {
        smallMario.SetActive(true);
        currentMario = smallMario;
        isInvincible = true;
        yield return new WaitForSeconds(0.3f);
      
        currentMario.transform.Find("Effect").gameObject.SetActive(true);
        playerRenderer = currentMario.transform.Find("Effect").transform.Find("TailMesh").GetComponent<SkinnedMeshRenderer>();
        originalAlpha = playerRenderer.material.color.a;

        Color originalColor = playerRenderer.material.color;




        yield return new WaitForSeconds(invincibleDuration);

        playerRenderer.material.color = new Color(1, 0, 0);

        yield return new WaitForSeconds(0.2f);

        playerRenderer.material.color = new Color(1, 1, 1);

        yield return new WaitForSeconds(0.2f);

        playerRenderer.material.color = new Color(1, 0, 0);

        yield return new WaitForSeconds(0.2f);

        playerRenderer.material.color = new Color(1, 1, 1);


        currentMario.transform.Find("Effect").gameObject.SetActive(false);



        isInvincible = false;


        //int n = 5;
        //while (n-- > 0)
        //{

        //    playerRenderer.material.color = new Color(1, 0, 0);


        //    yield return new WaitForSeconds(2f);
        //    playerRenderer.material.color = new Color(1, 1, 1);

        //}




    }

    public void GrowUp()
    {
        if(currentMario==smallMario)
        {
            bigMairo.transform.position = smallMario.transform.position;
            smallMario.SetActive(false);
            bigMairo.SetActive(true);
            currentMario = bigMairo;
        }
        

    }
    public void DropFail()
    {
        currentMario = bigMairo;
        currentMario.SetActive(false);
        currentMario.transform.position = spwanPosion.transform.position;
        currentMario.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentMario = bigMairo;
        currentMario.transform.position = spwanPosion.transform.position;
        gameStartUI.SetActive(true);
        gameEndUI.SetActive(false);
        gamingUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMario == bigMairo)
        {
            MPlayer.instance.jumpPower = 2.3f;
            anim = currentMario.transform.Find("Mario").GetComponent<Animator>();
        }
        else
        {
            MPlayer.instance.jumpPower = 2.5f;
            anim = currentMario.transform.Find("MarioMini").GetComponent<Animator>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (currentMario == smallMario)
            {
                bigMairo.transform.position = smallMario.transform.position;
                smallMario.SetActive(false);
                bigMairo.SetActive(true);
                currentMario = bigMairo;
                anim = currentMario.transform.Find("Mario").GetComponent<Animator>();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            currentMario.SetActive(false);
            currentMario.transform.position = endPosition.transform.position;
            currentMario.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            currentMario.SetActive(false);
            currentMario.transform.position = startPosition.transform.position;
            currentMario.SetActive(true);
        }
    }
    public void OnMyRePLAY()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMyQuit()
    {
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
