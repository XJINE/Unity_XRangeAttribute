using UnityEngine;

public class Sample : MonoBehaviour
{
    [Range(0, 3)]
    public Vector2 vector2Value;

    [Range(0, 3)]
    public int intValue;

    [Range(0, 3)]
    public float floatValue;

    [Range(10, 15)]
    public long longValue = 10;

    [Range(10, 15)]
    public double doubleValue = 10;

    [Range(0, 1)]
    public string stringValue;
}