using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;
		float _doubleTapDelay = 0.25f;//

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			//throw new NotImplementedException("TryTrashFood: this feature is not implemented");
			if ( (_place.CurFood == null) || (_place.CurFood.CurStatus != Food.FoodStatus.Overcooked) ) {
				return;
			}

			if ( Time.realtimeSinceStartup - _timer <= _doubleTapDelay ) {
				_place.FreePlace();
			}

			_timer = Time.realtimeSinceStartup;
		}
	}
}
