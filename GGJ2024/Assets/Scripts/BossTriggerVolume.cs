using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.GraphicsBuffer;

public class BossTriggerVolume : MonoBehaviour
{
    public Transform Boss;
    public GameObject CutsceneUIRoot;
    public PlayableDirector CutsceneTimelineDirector;
    public float CutsceneDelayInSeconds = 5;
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
            StartCoroutine(Appear(CutsceneDelayInSeconds));
        }

        if (Boss.IsDestroyed() && CutsceneUIRoot.activeSelf)
        {
            CutsceneUIRoot.SetActive(false);
        }
    }

    IEnumerator Appear(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (!Boss.IsDestroyed())
        {
            float speed = 3f;
            float step = speed * Time.deltaTime; // calculate distance to move
            Boss.position = Vector3.MoveTowards(Boss.position, transform.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            Debug.Log("Triggered");
            triggered = true;

            StartCoroutine(StartCutsceneAfterSeconds(CutsceneDelayInSeconds));
        }
    }

    void StartCutscene()
    {
        CutsceneUIRoot.SetActive(true);
        CutsceneTimelineDirector.Play();
    }

    IEnumerator StartCutsceneAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCutscene();
    }
}
