using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndPenalManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Score;
    public Text BestScore;
    public GameObject medal;
    public GameObject newImage;
    public GameObject overImage;
    public GameManager GM;
 
    //public bool isStopped;
    
    void Start(){
        overImage.SetActive(false);
    }

    public void OnEnable() {
        Score.text = GM.score.ToString();
        
        // current score
        
        if (GM.bestScore < GM.score) {
            GM.bestScore = GM.score;
            newImage.SetActive(true);
            medal.SetActive(true);
        }

        else {
            medal.SetActive(false);
            newImage.SetActive(false);
        }
        BestScore.text = GM.bestScore.ToString();

    }

    public void GameOver() {
        
        if (GM.hp == 0.0f) {
            GM.isStopped = true;
        }
    }
}
