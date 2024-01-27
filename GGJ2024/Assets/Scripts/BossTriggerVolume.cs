using System.Collections;
using System.Collections.Generic;
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
        if (triggered)
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
        

        


#if false
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(Boss.position, transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }
#endif
    }
}
