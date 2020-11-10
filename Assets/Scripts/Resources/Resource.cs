using UnityEngine;
using UnityEngine.Serialization;

namespace Resources
{
	[CreateAssetMenu]
	public class Resource : ScriptableObject
	{
		public Color color;
		[FormerlySerializedAs("goldAmountPerClick")] public int resourceAmountPerClick = 5;

		public int ResourceAmount {
			get => PlayerPrefs.GetInt(this.name, 1);
			set => PlayerPrefs.SetInt(this.name, value);
		}

		public void ProduceResource() {
			this.ResourceAmount += this.resourceAmountPerClick; // this.resourceAmount = this.resourceAmount + this.resourceAmountPerClick;
		}
	}
}