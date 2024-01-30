using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float platformSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, platformSpeed*Time.deltaTime, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ceiling"){
            Destroy(this.gameObject);
        }
    }
}
