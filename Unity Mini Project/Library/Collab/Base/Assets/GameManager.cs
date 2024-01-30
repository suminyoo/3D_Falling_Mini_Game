using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float hp;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 다시 시작하기
    public void RetryGame() {
        SceneManager.LoadScene(stage);
    }
}
