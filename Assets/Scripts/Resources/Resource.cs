using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class Resource : ScriptableObject {
	[FormerlySerializedAs("goldAmountPerClick")] public int resourceAmountPerClick = 5;
	[FormerlySerializedAs("goldPlayerPrefKey")] [SerializeField] private string resourcePlayerPrefKey = "Gold";

	public int ResourceAmount {
		get => PlayerPrefs.GetInt(resourcePlayerPrefKey, 1);
		set => PlayerPrefs.SetInt(resourcePlayerPrefKey, value);
	}

	public void ProduceResource() {
		this.ResourceAmount += this.resourceAmountPerClick; // this.resourceAmount = this.resourceAmount + this.resourceAmountPerClick;
	}
}