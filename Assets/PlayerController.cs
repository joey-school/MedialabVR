using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Animation wrenchDownAnimation;

    [SerializeField]
    private Transform unimog;

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
//#else
        if (OVRInput.GetDown (OVRInput.Button.PrimaryIndexTrigger)) {
            CloseHand();
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            OpenHand();
        }

        if (OVRInput.GetDown(OVRInput.Button.DpadUp))
        {

        }
#endif
    }

    private void MoveUnimog()
    {
        //unimog.position += 
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
