using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Permet au joueur de vendre ses plantes.
/// </summary>

public class PlantSelling : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private PlantData _plantData;
    [SerializeField]
    private GameObject _coinPrefab;
    [SerializeField]
    private GameObject _moneyFinal;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        var _plant = this.GetComponent<PlantGrow>();            

        if (_plant.HasGrew)
        {        
            StartCoroutine(WaitAndSell());
            MoneyManager.Instance.Sell(_plantData.PriceSell);
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    IEnumerator WaitAndSell()
    {
        var coin = Instantiate(_coinPrefab);
        coin.transform.position = this.transform.position;
        var screen_pos = _moneyFinal.GetComponent<RectTransform>().position;
        var pos = Camera.main.ScreenToWorldPoint(screen_pos);
        coin.transform.DOMove(pos, 1.0f);
        coin.transform.DOScale(new UnityEngine.Vector3(1.2f, 1.2f, 1.0f), 1.0f);
        yield return new WaitForSeconds(1.5f);
        Destroy(coin);
        Destroy(this.gameObject);
    }
}
