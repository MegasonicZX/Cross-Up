using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance_HotHead : MonoBehaviour
{
    public GameObject hotHead;
    GameObject temp;

    public float timer;
    public float timerSubtractor;
    float maxTimer;
    void Start()
    {
        maxTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= timerSubtractor * Time.deltaTime;
        }

        if (timer <= 0)
        {
            temp = Instantiate(hotHead, transform.position, transform.rotation);
            timer = maxTimer;
            Destroy(temp, 4f);
        }
    }
}
