using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform PlayerCamera;
    public Transform Hand;
    public Transform CurrentHoveringItem;
    public Transform CurrentItemInHand;
    public GameObject HandIcon;
    // public TextMeshProUGUI HoveringItemText;
    public FMODUnity.EventReference PickupSFX;
    public FMODUnity.EventReference ThrowSFX;
    public FMODUnity.EventReference WalkSFX;
    public float WalkSFXInterval = 0.8f;
    float walkTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

        GetComponent<StudioEventEmitter>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossEncounter"))
        {
            GetComponent<StudioEventEmitter>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (CurrentItemInHand == null)
            {
                if (CurrentHoveringItem != null)
                {
                    CurrentHoveringItem.SetParent(Hand, true);
                    Rigidbody rigidbody = CurrentHoveringItem.GetComponent<Rigidbody>();
                    rigidbody.isKinematic = true;
                    CurrentHoveringItem.localPosition = new Vector3();
                    CurrentHoveringItem.localRotation = Quaternion.identity;
                    CurrentItemInHand = CurrentHoveringItem;

                    FMODUnity.RuntimeManager.PlayOneShot(PickupSFX, transform.position);
                }
            }
            else
            {
                Rigidbody rigidbody = CurrentItemInHand.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                CurrentItemInHand.SetParent(null, true);
                rigidbody.AddForce(PlayerCamera.TransformDirection(Vector3.forward) * 30f, ForceMode.VelocityChange);
                CurrentItemInHand = null;

                FMODUnity.RuntimeManager.PlayOneShot(ThrowSFX, transform.position);
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            float multiplier = 1;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                multiplier = 1.6f;
            }
            walkTimer += Time.deltaTime * multiplier;
            if (walkTimer > WalkSFXInterval)
            {
                FMODUnity.RuntimeManager.PlayOneShot(WalkSFX, transform.position);
                walkTimer -= WalkSFXInterval;
            }
        }
        else
        {
            walkTimer = 0;
        }
    }

    public void OnPickableCollisionEnter(Collider other)
    {
        // Debug.Log("Pickable selected: " + other.name);
        CurrentHoveringItem = other.transform;
        HandIcon.SetActive(true);
        // HoveringItemText.text = other.name;
    }
    public void OnPickableCollisionExit(Collider other)
    {
        CurrentHoveringItem = null;
        HandIcon.SetActive(false);
        // HoveringItemText.text = "";
    }
}
