using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Resources
{
	[CreateAssetMenu]
	public class Resource : ScriptableObject
	{
		public Color color;
		public event Action OnResourceChange;
		public event Action<string> OnResourceChangeText;
		[FormerlySerializedAs("goldAmountPerClick")] public int resourceAmountPerClick = 5;

		public int ResourceAmount {
			get => PlayerPrefs.GetInt(this.name, 1);
			set
			{
				PlayerPrefs.SetInt(this.name, value);
				OnResourceChangeText?.Invoke(ResourceAmount.ToString($"0 {this.name}"));
				OnResourceChange?.Invoke();
			}
		}

		public void ProduceResource() => this.ResourceAmount += this.resourceAmountPerClick; // this.resourceAmount = this.resourceAmount + this.resourceAmountPerClick;

		public override string ToString() => ResourceAmount.ToString($"0 {this.name}");
	}
}