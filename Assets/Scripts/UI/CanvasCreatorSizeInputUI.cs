using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CanvasCreatorSizeInputUI: MonoBehaviour
    {

        [SerializeField] private InputField inputField;
        private void OnGUI()
        {
            if (!int.TryParse(inputField.text, out var result))
            {
                if (inputField.text != "")
                    inputField.text = CanvasCreatorUI.minPaletteSize.ToString();
            }
        }
    }
}