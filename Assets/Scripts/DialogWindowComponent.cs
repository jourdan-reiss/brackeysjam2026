using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class DialogWindowComponent : MonoBehaviour
{
    [SerializeField] private StringTransformer transformer;
    
    private VisualElement root;
    private VisualElement parent;

    private string currentText;
    
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        parent = root.Query<VisualElement>("Background");
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


    [Button]
    public void SetRandomText()
    {
        var strings = new[] {"one", "two", "three", "four", "five"};
        var random = new Random();

        var text = strings[random.Next(0, strings.Length)];
        SetLabel(text);
    }

    private void SetLabel(string text)
    {
        currentText = text;
        parent.Q<Label>().text = text;
    }

    [Button]
    public void ChangeFont()
    {
        if (currentText == string.Empty)
            return;

        var transformedText = transformer.Transform(currentText);
        SetLabel(transformedText);
    }
}
