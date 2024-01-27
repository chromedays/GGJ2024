using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    public PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            PlayerController.OnPickableCollisionEnter(other);
        }
    }

#if false
    private void OnTriggerStay(Collider other)
    {
            PlayerController.OnCollision(other);
    }
#endif

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            PlayerController.OnPickableCollisionExit(other);
        }
    }
}
