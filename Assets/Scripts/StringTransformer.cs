using System.Text;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "StringTransformer", menuName = "Scriptable Objects/StringTransformer")]
public class StringTransformer : ScriptableObject
{
    [SerializeField] private FontAsset font;

    public string Transform(string value)
    {
        // return $"<i>{value}</i>";
        // return string.Format("<font=\"{0}\">{1}</f>", font.name, value);
        
        return Reconstruct(Deconstruct(value));
    }
    
    private char[] Deconstruct(string value)
    {
        return value.ToCharArray();
    }

    private string Reconstruct(char[] value)
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < value.Length; i++)
        {
            var character = value[i];
            builder.Append(string.Format("<font=\"{0}\">{1}</f>", font.name, character));
        }
            
        return builder.ToString();
    } 
 }
