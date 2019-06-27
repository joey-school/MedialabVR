using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionController : MonoBehaviour
{

    [SerializeField]
    private Transform anchor;

    [SerializeField]
    private GameObject particles;

    private bool problemIsSolved = false;

    private GameObject branch;

    private void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            branch.GetComponent<Rigidbody>().isKinematic = false;
            problemIsSolved = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(8, this);
        if (other.tag == "Obstacle")
        {
            Debug.Log("Colliding with branch!", this);

            if (!problemIsSolved)
            {
                branch = other.gameObject;
                other.transform.position = anchor.position;
                particles.SetActive(false);
            }
        }
    }
}
