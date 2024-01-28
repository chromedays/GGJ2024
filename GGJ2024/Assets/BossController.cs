using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public EventReference DefeatSFX;
    public Transform Player;
    public PlayableDirector EndingTimelineDirector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAppear()
    {
        GetComponent<StudioEventEmitter>().Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickable"))
        {
            FMODUnity.RuntimeManager.PlayOneShot(DefeatSFX, Player.position);
            EndingTimelineDirector.Play();
            GetComponent<StudioEventEmitter>().Stop();
            Destroy(gameObject);
        }
    }
}
