#if UNITY_EDITOR

using UnityEngine;

namespace UnityEditor
{
    // NOTE:
    // This class hide a default Unity's RangeDrawer.

    [CustomPropertyDrawer(typeof(RangeAttribute))]
    internal sealed class RangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RangeAttribute range = (RangeAttribute)attribute;

            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:
                    {
                        EditorGUI.Slider(position, property, range.min, range.max, label);
                        break;
                    }
                case SerializedPropertyType.Integer:
                    {
                        EditorGUI.IntSlider(position, property, (int)range.min, (int)range.max, label);
                        break;
                    }
                default:
                    {
                        // NOTE:
                        // In default.
                        // EditorGUI.LabelField(position, label.text, "Use Range with float or int.");

                        // NOTE:
                        // RangeAttribute supports long and double field in default.
                        // However, such field value is rounded into a float value.

                        // NOTE:
                        // It is not good to clamp some vector or any other field value.
                        // Because the default GUI allows out of the range value.
                        // 
                        // property.longValue = Math.Min(Math.Max(property.longValue, (long)range.min), (long)range.max);
                        // property.vector2IntValue = new Vector2Int((int)Mathf.Clamp(property.vector2IntValue.x, range.min, range.max),
                        //                                           (int)Mathf.Clamp(property.vector2IntValue.y, range.min, range.max));

                        EditorGUI.PropertyField(position, property, true);
                        break;
                    }
            };
        }
    }
}

#endif // UNITY_EDITOR