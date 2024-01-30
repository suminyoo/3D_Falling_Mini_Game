using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public AudioSource[] AS;
    public GameManager GM;
    public GameObject EM;
    public GameObject Shiled;
    public float speed = 0.1f;
    private Rigidbody rigid;
    private Vector2 input;
    private Vector3 targetDirection;
    public bool isShielded = false;
    public bool isReverse = false;
    Renderer playerColor;
    public PlatformBehaviour PB;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
        playerColor = gameObject.GetComponent<Renderer>();

        isShielded = false;
        Shiled.SetActive(false);
    }

    private void FixedUpdate() {
        if(!GM.isStopped){
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 dir;

            if(isReverse){
                dir = new Vector3(-h,0,-v);
            }
            else{
                dir = new Vector3(h,0,v);
            }
            transform.Translate(dir*speed);
        }
    }


    // 총알과 Player가 부딪힘
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            if(isShielded == false){
                // Debug.Log("Attacked by Enemy");
                AS[6].Play();
                GM.hp -= 15.0f;
            }
            else{
                // Debug.Log("Using Sheild");
                AS[7].Play();
                isShielded = false;
            }
            Shiled.SetActive(false);
        }
        if(other.tag == "RedPlatform"){
            AS[0].Play();
            playerColor.material.color = new Color(68/255f, 230/255f, 230/255f, 80/255f);
            EM.GetComponent<EnemyController>().makeMoveEnemy();
        }
        if(other.tag == "OrangePlatform"){
            AS[1].Play();
            playerColor.material.color = new Color(230/255f, 140/255f, 78/255f, 80/255f);
            EM.GetComponent<EnemyController>().speedController += 0.015f;
        }
        if(other.tag == "YellowPlatform"){
            AS[2].Play();
            playerColor.material.color = new Color(255/255f, 255/255f, 120/255f, 80/255f);
            
            isShielded = true;
            Shiled.SetActive(true);
        }
        if(other.tag == "GreenPlatform"){
            AS[3].Play();
            playerColor.material.color = new Color(150/255f, 255/255f, 150/255f, 80/255f);
            EM.GetComponent<EnemyController>().speedController -= 0.015f;
        }
        if(other.tag == "BluePlatform"){
            AS[4].Play();
            playerColor.material.color = new Color(150/255f, 150/255f, 255/255f, 80/255f);
            GM.hp += 10.0f;
        }
        if(other.tag == "PurplePlatform"){
            AS[5].Play();
            playerColor.material.color = new Color(180/255f, 120/255f, 255/255f, 80/255f);
            if(isReverse == false){
                isReverse = true;
            }
            else{
                isReverse = false;
            }

        }
    }
}
