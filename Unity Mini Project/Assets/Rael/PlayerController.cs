using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager GM;
    public float speed = 0.1f;
    private Rigidbody rigid;
    private Vector2 input;
    private Vector3 targetDirection;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h,0,v);
        transform.Translate(dir*speed);
    }

    // 총알과 Player가 부딪힘
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy"){
            GM.hp -= 5.0f;
        }
    }
}
