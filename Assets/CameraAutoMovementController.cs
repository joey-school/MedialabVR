using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAutoMovementController : MonoBehaviour
{

    [SerializeField]
    private Transform start;

    private Vector3 endPosition;
    private Vector3 endRotation;

    private void Awake()
    {
        endPosition = transform.position;
        endRotation = transform.eulerAngles;
    }

    private void Start()
    {
        StartIntroAutoMovement();
    }

    private void StartIntroAutoMovement()
    {
        transform.position = start.position;
        transform.rotation = start.rotation;

        transform.DOMove(endPosition, 5f).SetEase(Ease.Linear);
        transform.DORotate(endRotation, 5f).SetEase(Ease.Linear);
    }
}
