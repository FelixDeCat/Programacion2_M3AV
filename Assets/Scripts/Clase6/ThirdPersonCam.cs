using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    float yaw = 0;
    float pitch = 0;
    [SerializeField] float rotSpeed = 5f;
    [SerializeField] float pitchMax = 60;
    [SerializeField] float pitchMin = -20;

    [SerializeField] Rigidbody rig;

    [SerializeField] float distance = 10f;
    [SerializeField] float height = 2f;

    Vector3 velocity = Vector3.zero;

    [SerializeField] float smoothTime = 0.1f;

    void Start()
    {
        yaw = rig.transform.eulerAngles.y;
        pitch = 0;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * rotSpeed;
        pitch -= mouseY * rotSpeed;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 desired =
            rig.position -
            rotation * Vector3.forward * distance +
            Vector3.up * height;


        transform.position = Vector3.SmoothDamp(
            transform.position,
            desired,
            ref velocity,
            smoothTime
            );


        Vector3 offset = Vector3.up * height * 0.5f;
        transform.LookAt(transform.position + offset);
    }
}
