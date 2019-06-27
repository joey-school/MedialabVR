using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private Transform rightHandAnchor;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private LayerMask layerMask;

    private void Update()
    {
        RaycastHit hit;

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (Physics.Raycast(rightHandAnchor.position, rightHandAnchor.forward, out hit, layerMask))
            {
                Debug.Log(hit.transform.name, this);

                hit.transform.parent.GetComponent<VRButton>().Click();
            }
        }

#if UNITY_EDITOR
        if (Physics.Raycast(rightHandAnchor.position, rightHandAnchor.forward, out hit, 1f, layerMask, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.transform.name, this);

            hit.transform.parent.GetComponent<VRButton>().Click();
        }
#endif

        Debug.DrawRay(rightHandAnchor.position, rightHandAnchor.forward * 1000f, Color.green);
    }

    public void OnClickMoveForwardButton()
    {
        Debug.Log("Move forward!", this);

        playerController.IsMovingForward = true;
    }

    public void OnClickMoveBackwardsButton()
    {
        Debug.Log("Move backwards!", this);

        playerController.IsMovingForward = false;
    }

    public void OnClickUseHandButton()
    {
        playerController.SwapTools();
    }

    public void OnClickUseWrenchButton()
    {
        playerController.SwapTools();
    }
}
