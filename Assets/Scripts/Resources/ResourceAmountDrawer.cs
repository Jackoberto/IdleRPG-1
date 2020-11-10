using UnityEditor;
using UnityEngine;

namespace Resources {
    // TODO: Hint for exercise for property drawers
    [CustomPropertyDrawer(typeof(ResourceAmount))]
    public class ResourceAmountDrawer : PropertyDrawer
    {
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            ResourceAmount resourceAmount = (ResourceAmount) fieldInfo.GetValue(property.serializedObject.targetObject);
            EditorGUI.LabelField(new Rect(position.x, position.y, EditorGUIUtility.labelWidth, position.height), label);
            var width = (position.width - EditorGUIUtility.labelWidth);
            var amount = EditorGUI.IntField(new Rect(position.x+EditorGUIUtility.labelWidth, position.y, width*0.3f, position.height), resourceAmount.amount);
            var resource = (Resource)EditorGUI.ObjectField(new Rect(position.x+EditorGUIUtility.labelWidth+width*0.3f, position.y, width*0.7f, position.height), resourceAmount.resourceType, typeof(Resource));
            resourceAmount.amount = amount;
            resourceAmount.resourceType = resource;
            fieldInfo.SetValue(property.serializedObject.targetObject, resourceAmount);
        }
    }
}