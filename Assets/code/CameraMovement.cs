using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera camera;
    [Space]
    public float cameraPlaneSpeed = -.05f;
    public float cameraVerticalSpeed = -.2f;
    [Space]
    public Vector3 maxPosition = new Vector3(7, 7, 2);
    public Vector3 minPosition = new Vector3(-2, 3, -7);

    new private void Start()
    {
        camera = Camera.main;
        Input.multiTouchEnabled = true;
        Input.simulateMouseWithTouches = true;
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        Touch[] Touches = Input.touches;
        Vector3 cameraDirection = Vector3.zero;
        float directionMultiplier = 1;
        if (Input.touchCount == 2)
        {
            float dotProduct = Vector2.Dot(Touches[0].deltaPosition, Touches[1].deltaPosition);
            if (dotProduct < 0)
            {
                // zoom
                Vector2 deltaPos = Touches[0].position - Touches[1].position;
                Vector2 deltaVel = Touches[0].deltaPosition - Touches[1].deltaPosition;
                dotProduct = Math.Sign(Vector2.Dot(deltaPos, deltaVel));
                directionMultiplier = cameraVerticalSpeed * dotProduct;
                Vector3 input = Vector3.up;
                cameraDirection = input;
            }
            else
            {
                // move
                directionMultiplier = cameraPlaneSpeed;
                Vector2 input = (Touches[0].deltaPosition + Touches[1].deltaPosition) / 2f;
                cameraDirection = new Vector3(input.x - input.y, 0, input.x + input.y) / 2f;
            }
        }
        else if (Input.touchCount == 1)
        {
            // move
            directionMultiplier = cameraPlaneSpeed;
            Vector2 input = Touches[0].deltaPosition;
            cameraDirection = new Vector3(input.x - input.y, 0, input.x + input.y) / 2f;
        }
        camera.transform.position += cameraDirection * directionMultiplier;
        camera.transform.position = new Vector3(
            Mathf.Clamp(camera.transform.position.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(camera.transform.position.y, minPosition.y, maxPosition.y),
            Mathf.Clamp(camera.transform.position.z, minPosition.z, maxPosition.z)
            );
    }
}