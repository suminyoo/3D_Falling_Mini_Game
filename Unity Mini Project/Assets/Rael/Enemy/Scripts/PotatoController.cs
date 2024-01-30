using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoController : MonoBehaviour
{
    public float mvSpeed;
    public float rotSpeed = 200.0f;
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        mvSpeed = 0.003f;
        myPos = transform.position;

        //반대 Pos를 잡아 날아가도록 함
        targetPos = new Vector3(-myPos.x, 0, -myPos.z);
        
        newPos = (targetPos - myPos) * mvSpeed;

        //일정 시간 뒤, Destroy
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotSpeed*Time.deltaTime, 0));
        transform.position = transform.position + newPos;
    }
}
