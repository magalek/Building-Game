using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour, IManager
{
    public Camera Camera { get; private set; }

    private void Awake() {
        Camera = GetComponent<Camera>();
        Managers.RegisterManager(this);
    }
}
