using UnityEngine;
using UnityEngine.UI;

namespace Play
{
    public class PlayManager: MonoBehaviour
    {
        [SerializeField] private Slider speedSlider = null;
        //TODO: neighbour structure selector

        public static float speed;
        private void Awake()
        {
            speedSlider.onValueChanged.AddListener(delegate
            {
                OnSliderValueChangedHandler();
            });
        }

        private void OnSliderValueChangedHandler()
        {
            speed = speedSlider.value;
        }
    }
}