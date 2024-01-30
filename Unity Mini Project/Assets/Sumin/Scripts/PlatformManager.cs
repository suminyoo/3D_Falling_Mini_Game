using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float timer;
    private int waitingTime;

    public List<GameObject> platforms;
    // public GameObject bullet;
    void Start()
    {
        timer = 0.0f;
        waitingTime = 1;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > waitingTime){
            int randomNumber = Random.Range(0, 6);
            float switchValue = Random.value;
            float xValue = Random.Range(-14f, 14f);
            float zValue = Random.Range(-8f, 8f);

            Instantiate(platforms[randomNumber], new Vector3(xValue, -50, zValue), Quaternion.identity);
            
            int randomNumber2 = Random.Range(0, 6);
            float xValue2 = Random.Range(-14f, 14f);
            float zValue2 = Random.Range(-8f, 8f);

            Instantiate(platforms[randomNumber2], new Vector3(xValue2, -50, zValue2), Quaternion.identity);
            timer = 0;

        }
    }

    // void Update()
    // {
    //     RandomX = UnityEngine.Random.Range(-1f, 1f);
    //     RandomZ = UnityEngine.Random.Range(-0.5f, -0.5f);
    //     RandomPos = new Vector3(RandomX, -20 ,RandomZ);

    //     transform.Translate(Vector3.up*platformSpeed*Time.deltaTime);
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.tag == "Ceiling"){
    //         Destroy(this.Platform, 1.0f);
    //     }
    // }
}
