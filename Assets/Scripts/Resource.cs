using UnityEngine;

[CreateAssetMenu]
public class Resource : ScriptableObject {
	public int goldAmountPerClick = 5;
	[SerializeField] private string goldPlayerPrefKey = "Gold";

	public int GoldAmount {
		get => PlayerPrefs.GetInt(goldPlayerPrefKey, 1);
		set => PlayerPrefs.SetInt(goldPlayerPrefKey, value);
	}

	public void ProduceGold() {
		this.GoldAmount += this.goldAmountPerClick; // this.GoldAmount = this.GoldAmount + this.goldAmountPerClick;
	}
}