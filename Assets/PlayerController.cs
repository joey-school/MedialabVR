using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Animation wrenchDownAnimation;

    [SerializeField]
    private Transform unimog;

    [SerializeField]
    private float unimogSpeedMultiplier = 1f;

    [SerializeField]
    private Text directionText;

    private bool isMovingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetMouseButtonDown (0)) {
            CloseHand();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OpenHand();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUnimog(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveUnimog(Vector3.back);
        }
#else
        if (OVRInput.GetDown (OVRInput.Button.PrimaryIndexTrigger)) {
            CloseHand();
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            OpenHand();
        }

        if (OVRInput.Get(OVRInput.Button.DpadUp))
        {
            isMovingForward = true;
            directionText.text = "Moving forward";
        }
        else if (OVRInput.Get(OVRInput.Button.DpadDown))
        {
            isMovingForward = false;
            directionText.text = "Moving backwards";
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || OVRInput.Get(OVRInput.Button.Down))
        {
            if (isMovingForward)
            {
                MoveUnimog(Vector3.forward);
            }
            else
            {
                MoveUnimog(Vector3.back);
            }
        }
#endif
    }

    private void MoveUnimog(Vector3 direction)
    {
        unimog.position += direction * unimogSpeedMultiplier * Time.deltaTime;
    }

    private void CloseHand()
    {
        wrenchDownAnimation.Play("close");
    }

    private void OpenHand()
    {
        wrenchDownAnimation.Play("open");
    }
}
