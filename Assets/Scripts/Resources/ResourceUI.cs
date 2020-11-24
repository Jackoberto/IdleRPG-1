using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Resources
{
	public class ResourceUI : MonoBehaviour
	{
		public Text resourceAmountText;

		public void SetUp(Resource resource)
		{
			resource.OnResourceChangeText += s => this.resourceAmountText.text = s;
			resourceAmountText.color = resource.color;
			this.resourceAmountText.text = resource.ToString();
		}
	}
}
