using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NTools.Extensions
{
    public static class EngineExtension
    {
        public static void AddListener(this Button button, UnityAction action) => button.onClick.AddListener(action);
        public static void RemoveListener(this Button button, UnityAction action) => button.onClick.RemoveListener(action);
        public static void RemoveListenerAll(this Button button) => button.onClick.RemoveAllListeners();

        public static void AddListener(this Slider slider, UnityAction<float> action) => slider.onValueChanged.AddListener(action);
        public static void RemoveListener(this Slider slider, UnityAction<float> action) => slider.onValueChanged.RemoveListener(action);
        public static void RemoveListenerAll(this Slider slider) => slider.onValueChanged.RemoveAllListeners();

        public static void SetActive(this Component component, bool active) => component.gameObject.SetActive(active);
    }
}