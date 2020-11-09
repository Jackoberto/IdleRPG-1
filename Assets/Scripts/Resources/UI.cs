using UnityEngine;
using UnityEngine.UI;

namespace Resources
{
	public class UI : MonoBehaviour {
		public Text resourceAmountText;
		public Resource resource;

		void UpdateResourceAmountLabel()
		{
			this.resourceAmountText.text = resource.ResourceAmount.ToString($"0 {resource.name}");
		}

		void Update() {
			UpdateResourceAmountLabel();
		}
	}
}
