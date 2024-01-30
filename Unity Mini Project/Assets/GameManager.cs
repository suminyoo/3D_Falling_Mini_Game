using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static Image healthyBar;
    public AudioSource BG;
    //public AudioSource Retry;
    //public AudioSource Exit;
    public float hp;
    //public float currentHP;
    public int score = 0;
    public int bestScore = 0;
    public float maxHP = 100.0f;
    public int stage;

    //public Slider Slider;
    public static float healthy;

    public Text textTime;
    public Text currentScore;
    public EndPenalManager EM;

    private float timeStart;
    private float timeCurrent;
    private float timeDuring;
    public bool isStopped;

    public GameObject overImage;
    public Text Hptext;
    public Text scoreText;

    // 시간이 증가함에 따라 해야할 일은 점수 증가와 HP감소
    private void Awake() {   
        StartCoroutine(scoreCount());
    }

    // Start is called before the first frame update
    void Start()
    {   
        hp = 100.0f;
        BG.Play();

        //Slider = GetComponent<Slider>();
        timeStart = 5.0f;
        timeDuring = 0.0f;
        healthyBar = GetComponent<Image>();
    }

    public static void SetHealthyvalue(float value) {
        healthyBar.fillAmount = value;
    }
    
    void Update() {
       // healthy = Slider.value;
        timeDuring += Time.deltaTime;
        textTime.text = "time: " + Mathf.Round(timeDuring);
        currentScore.text = score.ToString();

        Hptext.text = hp.ToString();
        if(hp < 0.0f) {
            isStopped = true;
            scoreText.text = score.ToString();
            overImage.SetActive(true);
            EM.OnEnable();
        }
    }

    // 시간이 흐르면서 
    private IEnumerator scoreCount() {
        // when your char onclick 
        while(!isStopped) {
            yield return new WaitForSeconds(1.0f);
            score += 10;
            hp -= 1.0f;
        }

    }

    public void checkScore() {
        timeCurrent = Time.time - timeStart;
    }
    
    // 다시 시작하기
    public void RetryGame() {
        SceneManager.LoadScene(stage); 
        score = 0;
        //Retry.Play();
    }

    // 종료
    public void ExitGame() {
        //Exit.Play();
        // two method 
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
