using Chemicals;
using Saving;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ChemicalSelectorDropdownUI: MonoBehaviour
    {
        [SerializeField] private Dropdown chemicalSelectorDropdown = null;

        private void Awake()
        {
            chemicalSelectorDropdown.onValueChanged.AddListener(delegate
            {
                OnDropdownValueChangedHandler();
            });

            ChemicalManager.onCacheRefreshed += UpdateChemicalsList;
        }

        private void OnDropdownValueChangedHandler()
        {
            string chemicalName = chemicalSelectorDropdown.options[chemicalSelectorDropdown.value].text;
            ChemicalManager.ChangeSelectedChemical(chemicalName);
        }

        private void UpdateChemicalsList()
        {
            chemicalSelectorDropdown.options.Clear();

            var savedChemicals = ChemicalManager.allChemicals;

            foreach (var chemical in savedChemicals)
            {
                var chemicalName = chemical.chemicalName;
                var optionData = new Dropdown.OptionData(chemicalName);
                chemicalSelectorDropdown.options.Add(optionData);
            }
        }
    }
}