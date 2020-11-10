using Clicker;
using UnityEngine;

namespace Resources
{
	public class ResourceUISetup : MonoBehaviour {

		public Resource[] resources;
		public ResourceUI resourceUIPrefab;

		void Start() {
			foreach (var resource in this.resources) {
				var instance = Instantiate(this.resourceUIPrefab, this.transform);
				instance.SetUp(resource);
			}
		}
	}
}