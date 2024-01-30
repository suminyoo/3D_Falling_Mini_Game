using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    Vector3 targetPos;
    Vector3 myPos;
    Vector3 newPos;
    int cnt;

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        //일정 시간 뒤, Destroy
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //크기 점점 커지게
        if(cnt < 10){
            transform.localScale += new Vector3(0.4f,0,0.4f);
            cnt++;
        }
    }
}
