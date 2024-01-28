using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public EventReference DefeatSFX;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickable"))
        {
            FMODUnity.RuntimeManager.PlayOneShot(DefeatSFX, Player.position);
            Destroy(gameObject);
        }
    }
}
