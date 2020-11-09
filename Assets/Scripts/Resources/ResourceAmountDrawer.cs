using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Resources
{
    //[CustomPropertyDrawer(typeof(ResourceAmount))]
    public class ResourceAmountDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new VisualElement();
            
            var amount = new PropertyField(property.FindPropertyRelative("amount"));
            var resource = new PropertyField(property.FindPropertyRelative("resourceType"));
            container.Add(amount);
            container.Add(resource);
            return container;
        }
    }
}