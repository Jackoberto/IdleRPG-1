using UnityEngine;
using UnityEngine.Events;

namespace Resources
{
	public class ResourceUI : MonoBehaviour
	{
		public UnityEvent<string> resourceAmountChange;
		public UnityEvent<Color> resourceColorChange;

		public void SetUp(Resource resource)
		{
			resource.OnResourceChangeText += s => resourceAmountChange.Invoke(s);
			resourceColorChange.Invoke(resource.color);
			resourceAmountChange.Invoke(resource.ToString());
		}
	}
}
