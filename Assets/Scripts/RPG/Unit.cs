using UnityEngine;

public class Unit : MonoBehaviour {
	public float attackTime = 0.6f;
	public float damage = 5f;
	public float health = 100f;
	float elapsedTime;

	GameObject Target => GetComponent<Target>().value;
	bool HasTarget => GetComponent<Target>() != null && GetComponent<Target>().Exists;
	bool CanAttack => !this.IsChargingAttack && this.HasTarget;
	bool IsChargingAttack => this.elapsedTime < this.attackTime;
	bool IsDead => this.health <= 0f;

	void Update() {
		UpdateTime();
		if (this.CanAttack) {
			Attack();
		}
	}

	void UpdateTime() {
		this.elapsedTime += Time.deltaTime;
	}

	void Attack() {
		var unit = this.Target.GetComponent<Unit>();
		unit.TakeDamage(this.damage);
		Debug.Log($"{this} attacks {this.Target} for {this.damage} damage!", this);
		this.elapsedTime -= this.attackTime;
	}

	public void TakeDamage(float damage) {
		this.health -= damage;
		if (this.IsDead) {
			Destroy(this.gameObject);
		}
	}
}