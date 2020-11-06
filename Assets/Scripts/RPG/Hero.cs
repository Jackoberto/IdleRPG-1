using UnityEngine;

public class Hero : MonoBehaviour {
	bool HasTarget => GetComponent<Target>() != null;
	void Update() {
		if (!this.HasTarget) {
			var enemy = FindObjectOfType<Enemy>();
			if (enemy != null) {
				var target = this.gameObject.AddComponent<Target>();
				target.value = enemy.gameObject;
			}
		}
	}
}