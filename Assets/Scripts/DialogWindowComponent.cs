using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogWindowComponent : MonoBehaviour
{
    private VisualElement root;
    private VisualElement parent;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        parent = root.Q<VisualElement>("Background");
    }

    [Button]
    public void HideDialog()
    {
        parent.AddToClassList("HideElement");
    }

    [Button]
    public void ShowDialog()
    {
        parent.RemoveFromClassList("HideElement");

    }
}
