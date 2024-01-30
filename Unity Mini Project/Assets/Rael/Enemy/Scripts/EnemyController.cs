using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManager GM;              //GameManager 정의
    public GameObject FireObj;          //적 Prefab 정의
    public GameObject PotatoObj;        //감자 Prefab 정의
    public GameObject MoveObj;          //움직이는 적 Prefab 정의
    public float speedController;       //발판 별 적 속도 변경
    public float highScore = 300.0f;    //highScore 지정

    GameObject enemyPos;
    bool isHighScore;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRepeat());
        StartCoroutine(PotatoRepeat());
        isHighScore = true;
        speedController = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //고득점이 되면 (Flag 세워서 한번만!!!)
        if(isHighScore && GM.score > highScore){
            StartCoroutine(MoveRepeat());
            StartCoroutine(FireRepeat());
            isHighScore = false;
        }
    }

    public void makeMoveEnemy(){
        FlowerEnemy(MoveObj);
    }

    private IEnumerator FireRepeat(){
        int randTime = (int)Random.Range(2, 4);

        while(true){
            yield return new WaitForSeconds(randTime);
            FireEnemy(FireObj);
            randTime = (int)Random.Range(2, 5);
        }
    }

    private IEnumerator PotatoRepeat(){
        int randTime = (int)Random.Range(4, 8);

        while(true){
            yield return new WaitForSeconds(randTime);
            FireEnemy(PotatoObj);
            randTime = (int)Random.Range(5, 10);
        }
    }

    private IEnumerator MoveRepeat(){
        int randTime = (int)Random.Range(4, 8);

        while(true){
            yield return new WaitForSeconds(randTime);
            FlowerEnemy(MoveObj);
            randTime = (int)Random.Range(10, 15);
        }
    }

    void FireEnemy(GameObject objType){
        float switchValue = Random.value;
        float xValue = Random.Range(-15f, 15f);
        float zValue = Random.Range(-10f, 10f);

        if(switchValue > 0.5f){
            if(Random.value > 0.5f){
                Instantiate(objType, new Vector3(-15f, 0f, zValue), Quaternion.identity);
            } 
            else{
                Instantiate(objType, new Vector3(15f, 0f, zValue), Quaternion.identity);
            }
        }
        else{
            if(Random.value > 0.5f){
                Instantiate(objType, new Vector3(xValue, 0f, -10f), Quaternion.identity);
            } 
            else{
                Instantiate(objType, new Vector3(xValue, 0f, 10f), Quaternion.identity);
            }
        }
    }
    void FlowerEnemy(GameObject objType){
        float xValue = (int)Random.Range(-10f, 10f);
        float zValue = (int)Random.Range(-7f, 7f);

        Instantiate(objType, new Vector3(xValue, 0f, zValue), Quaternion.identity);
    }
}
