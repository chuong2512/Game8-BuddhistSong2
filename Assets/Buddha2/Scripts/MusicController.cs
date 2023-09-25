using TMPro;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public int currentMusic;
    private PlayerData playerData; //todo delete
    private GameDataManager gameData; //todo delete
    public TextMeshProUGUI diamonds;
    public TextMeshProUGUI musicCoins;
    public GameObject inApp;
    public PopUp popup;

    void OnEnable()
    {
        gameData = GameDataManager.Instance;
        playerData = gameData.playerData;

        diamonds.text = "x" + playerData.intDiamond;
        musicCoins.text = diamonds.text;
        if (currentMusic > -1)
        {
            //AudioManager.Instance.PlaySong(currentMusic);
            //AudioManager.Instance.Play();
        }
    }

    void Start()
    {
        gameData = GameDataManager.Instance;
        playerData = gameData.playerData;
    }

    public void ShowPopup(int price, int id)
    {
        popup.Show(price, id);
    }

    public void Pay(int price, int id)
    {
        if (!playerData.CheckCanUnlock(price, id)) return;
        playerData.Unlock(id);
        diamonds.text = "x" + playerData.intDiamond;
        musicCoins.text = diamonds.text;
        popup.gameObject.SetActive(false);
    }

    public void AddDiamonds(int value)
    {
        /*IAPManager.OnPurchaseSuccess = () =>
        {
            playerData.AddDiamond(value);
            diamonds.text = "x" + playerData.intDiamond;
            musicCoins.text = diamonds.text;
        };

        switch (value)
        {
            case 5:
                IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                break;
            case 10:
                IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                break;
            case 25:
                IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                break;
            case 50:
                IAPManager.Instance.BuyProductID(IAPKey.PACK4);
                break;
            case 100:
                IAPManager.Instance.BuyProductID(IAPKey.PACK5);
                break;
            case 250:
                IAPManager.Instance.BuyProductID(IAPKey.PACK6);
                break;
        }*/
    }
}