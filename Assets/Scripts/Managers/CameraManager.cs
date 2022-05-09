using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, IManager
{
    public Camera Camera { get; private set; }

    [SerializeField, Range(0.1f, 0.5f)] private float cameraMoveThreshold;
    [SerializeField, Range(0f, 1f)] private float cameraMoveSpeed;

    private void Awake() {
        Camera = GetComponent<Camera>();
        Managers.RegisterManager(this);
    }

    private void LateUpdate() {
        Move();
    }

    private void Move() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x /= Screen.width;
        mousePos.z = mousePos.y / Screen.height;
        mousePos.y = 0;
        mousePos.x -= 0.5f;
        mousePos.z -= 0.5f;
        Vector3 translation = new Vector3();
        if (mousePos.x >= cameraMoveThreshold) translation.x = cameraMoveSpeed;
        if (mousePos.x <= -cameraMoveThreshold) translation.x = -cameraMoveSpeed;
        if (mousePos.z >= cameraMoveThreshold) translation.z = cameraMoveSpeed;
        if (mousePos.z <= -cameraMoveThreshold) translation.z = -cameraMoveSpeed;
        transform.position += translation;
    }
}
