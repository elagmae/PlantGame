using TMPro;
using UnityEngine;

/// <summary>
/// 
/// </summary>
 
public class SeedCount : MonoBehaviour
{
    [SerializeField]
    public PlantData _plantData;
    [SerializeField]
    private BuyingBehaviour _buyingBehaviour;
    [SerializeField]
    private InventoryManager _inventoryManager;

    private void Update()
    {
        Possess();
    }

    public void Possess()
    {
        if (this._plantData == _buyingBehaviour._plantData && _inventoryManager.m_Plants.ContainsKey(_plantData))
        {
            var plantPossess = GetComponentInChildren<TextMeshProUGUI>();
            plantPossess.text = _inventoryManager.m_Plants[_plantData].ToString();
        }

    }
}
