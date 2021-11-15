using System;
using CookingPrototype.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CookingPrototype.UI {
	public sealed class StartWindow : MonoBehaviour {
		public TMP_Text GoalText = null;
		public Button StartButton = null;
		public Button CloseButton = null;
		bool _isInit;


		void Init() {
			var gc = GameplayController.Instance;
			StartButton.onClick.AddListener(gc.StartGame);
			CloseButton.onClick.AddListener(gc.CloseGame);
			GoalText.text = $"{gc.OrdersTarget}";	//Определяем кол-во необходимых заказов
			_isInit = true;
		}

		public void Show() {
			if ( !_isInit ) {

				Init();
				_isInit = true;
			}
			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}