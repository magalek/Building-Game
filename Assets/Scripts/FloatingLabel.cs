using UnityEngine;
using TMPro;
using System;

public class FloatingLabel : MonoBehaviour {

    public bool IsShowing => elapsedTime < showTime;

    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private float showTime;

    private RectTransform rectTransform;

    private CameraManager cameraManager;

    private float elapsedTime;
    private Transform parent;

    private Action<FloatingLabel> releaseCallback;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update() {
        if (!gameObject.activeSelf) return;

        if (IsShowing) {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / showTime;
            Vector3 parentPosition = cameraManager.Camera.WorldToScreenPoint(parent.position + (normalizedTime * (Vector3.up + Vector3.forward)));
            rectTransform.position = parentPosition;
            Color color = label.color;
            color.a = 1 - normalizedTime;
            label.color = color;
        }
        else {
            gameObject.SetActive(false);
            releaseCallback?.Invoke(this);
        }
    }

    public void Show(string text, Transform _parent, Action<FloatingLabel> _releaseCallback) {
        cameraManager = Managers.GetManager<CameraManager>();
        parent = _parent;
        rectTransform.position = cameraManager.Camera.WorldToScreenPoint(parent.position);
        label.text = text;
        elapsedTime = 0;
        gameObject.SetActive(true);
        releaseCallback = _releaseCallback;
    }

    private void Reset() {
        label = GetComponent<TextMeshProUGUI>();
    }
}
