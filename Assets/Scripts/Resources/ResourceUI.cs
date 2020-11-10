using UnityEngine;
using UnityEngine.UI;

namespace Resources
{
	public class ResourceUI : MonoBehaviour {
		public Text resourceAmountText;
		public Resource resource;

		public void SetUp(Resource resource)
		{
			this.resource = resource;
			resourceAmountText.color = resource.color;
		}

		void UpdateResourceAmountLabel()
		{
			this.resourceAmountText.text = resource.ResourceAmount.ToString($"0 {resource.name}");
		}

		void Update() {
			UpdateResourceAmountLabel();
		}
	}
}
