using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SongButton : MonoBehaviour
{
    [SerializeField] private int _songID;
    [SerializeField] private Image _songImage;
    [SerializeField] private Button _button;

    [SerializeField] private GameObject _lockObj;
    [SerializeField] private GameObject _chooseObj;

    private bool _isUnlock;

    public bool IsUnlock
    {
        get => _isUnlock;
        set => _isUnlock = value;
    }

    public int SongID
    {
        get => _songID;
        set => _songID = value;
    }

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    void Start()
    {
        _button?.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        if (_isUnlock)
        {
            UIManager.Instance.OpenScreen<SongModel>(ScreenType.SongScreen, new SongModel()
            {
                songID = _songID
            });
        }
        else
        {
            UIManager.Instance.OpenScreen(ScreenType.UnlockPopup);
        }
    }

    public void SetID(int id)
    {
        _songID = id;
        _isUnlock = GameDataManager.Instance.playerData.CheckLock(_songID);

        var songSo = GameDataManager.Instance.songSo;
        _songImage.sprite = songSo.GetSongWithID(_songID).icon;
        Refresh();
    }

    public void Refresh()
    {
        _lockObj.SetActive(!_isUnlock);
        Choose(_songID == GameDataManager.Instance.currentID);
    }

    public void Choose(bool b)
    {
        _chooseObj.SetActive(false);
    }
}