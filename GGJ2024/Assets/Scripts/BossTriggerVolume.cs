using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossTriggerVolume : MonoBehaviour
{
    public Transform Boss;
    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !Boss.IsDestroyed())
        {
            float speed = 3f;
            float step = speed * Time.deltaTime; // calculate distance to move
            Boss.position = Vector3.MoveTowards(Boss.position, transform.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        triggered = true;
    }
}
