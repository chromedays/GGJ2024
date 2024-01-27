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

    // Start is called before the first frame update
    void Start()
    {

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
                }
            }
            else
            {
                Rigidbody rigidbody = CurrentItemInHand.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                CurrentItemInHand.SetParent(null, true);
                rigidbody.AddForce(PlayerCamera.TransformDirection(Vector3.forward) * 30f, ForceMode.VelocityChange);
                CurrentItemInHand = null;
            }
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
