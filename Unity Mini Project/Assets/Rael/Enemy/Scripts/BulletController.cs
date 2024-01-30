using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float mvSpeed;
    public float rotSpeed = 150.0f;
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        mvSpeed = Random.Range(0.01f, 0.02f) + GameObject.Find("FirePoses").GetComponent<EnemyController>().speedController;
        //Player 방향으로 날아가도록 함
        targetPos = GameObject.Find("Player").transform.position;
        myPos = transform.position;
        
        if(mvSpeed < 0.01f){
            mvSpeed = 0.01f;
        }
        newPos = (targetPos - myPos) * mvSpeed;

        //일정 시간 뒤, Destroy
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed*Time.deltaTime));
        transform.position = transform.position + newPos;
    }
}
