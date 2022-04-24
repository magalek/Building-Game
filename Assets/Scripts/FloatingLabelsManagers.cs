using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingLabelsManagers : MonoBehaviour, IManager
{
    [SerializeField] private FloatingLabel floatingLabelPrefab;

    private Stack<FloatingLabel> labelsStack = new Stack<FloatingLabel>();

    private void Awake() {
        Managers.RegisterManager(this);

        for (int i = 0; i < 20; i++) {
            FloatingLabel label = Instantiate(floatingLabelPrefab, transform);
            label.gameObject.SetActive(false);
            labelsStack.Push(label);
        }
    }

    public void Show(string text, Transform parent) {
        var label = labelsStack.Pop();
        label.Show(text, parent, Release);
    }

    private void Release(FloatingLabel label) {
        labelsStack.Push(label);
    }
}
