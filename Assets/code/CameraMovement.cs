using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    new private Camera camera;
    [Space]
    public float cameraRotationSpeed = -.05f;
    public float cameraPlaneSpeed = -.05f;
    public float cameraVerticalSpeed = -.2f;
    [Space]
    public Vector3 maxPosition = new Vector3(5, 3, 5);
    public Vector3 minPosition = new Vector3(-5, -3, -5);
    public Vector2 rotationRange = new Vector2(15, 75);

    private void Start()
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

        Vector2 cameraRotation = Vector2.zero;

        if (Input.touchCount == 2)
        {
            float dotProduct = Vector2.Dot(Touches[0].deltaPosition, Touches[1].deltaPosition);
            if (dotProduct < 0)
            {
                // move Y
                Vector2 deltaPos = Touches[0].position - Touches[1].position;
                Vector2 deltaVel = Touches[0].deltaPosition - Touches[1].deltaPosition;
                dotProduct = Math.Sign(Vector2.Dot(deltaPos, deltaVel));
                cameraDirection = Vector3.up * cameraVerticalSpeed * dotProduct;
            }
            else
            {
                // rotate
                Vector2 input = (Touches[0].deltaPosition + Touches[1].deltaPosition) / 2f;
                cameraRotation = new Vector3(input.x, input.y) * cameraRotationSpeed;
            }
        }
        else if (Input.touchCount == 1)
        {
            // move X Z
            Vector2 input = Touches[0].deltaPosition;
            cameraDirection =
                camera.transform.parent.right * input.x +
                camera.transform.parent.forward * input.y;
            cameraDirection *= cameraPlaneSpeed;
        }

        camera.transform.parent.position += cameraDirection;
        camera.transform.parent.position = new Vector3(
            Mathf.Clamp(camera.transform.parent.position.x, minPosition.x, maxPosition.x),
            Mathf.Clamp(camera.transform.parent.position.y, minPosition.y, maxPosition.y),
            Mathf.Clamp(camera.transform.parent.position.z, minPosition.z, maxPosition.z)
            );

        camera.transform.parent.Rotate(new Vector3(0, cameraRotation.x, 0));
        camera.transform.Rotate(new Vector3(cameraRotation.y, 0, 0));
        camera.transform.rotation = Quaternion.Euler(
            Mathf.Clamp(camera.transform.rotation.eulerAngles.x, rotationRange.x, rotationRange.y),
            camera.transform.rotation.eulerAngles.y,
            camera.transform.rotation.eulerAngles.z
            );
    }
}