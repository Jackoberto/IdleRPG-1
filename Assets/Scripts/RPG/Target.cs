using UnityEngine;

public class Target : MonoBehaviour {

    public bool Exists => this.value != null;
    
    public GameObject value;

    void Update() {
        if(!this.Exists)
            Destroy(this);
    }
}
