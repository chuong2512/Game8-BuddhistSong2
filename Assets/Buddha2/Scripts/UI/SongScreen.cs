using System;
using ABCBoard.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongScreen : BaseScreenWithModel<SongModel>
{
    private int _songID;

    [SerializeField] private Image _songImage;
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private TextMeshProUGUI _nameText;

    void Start()
    {
        _buttonPlay?.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        AudioManager.Instance.PlaySong(_songID);
    }

    public override void BindData(SongModel model)
    {
        _songID = model.songID;
        SetImage();
    }

    private void SetImage()
    {
        var songSo = GameDataManager.Instance.songSo;
        _songImage.sprite = songSo.GetSongWithID(_songID).icon;
        _nameText.SetText(songSo.GetSongWithID(_songID).name);
    }

    public override ScreenType GetID() => ScreenType.SongScreen;
}

public class SongModel
{
    public int songID;
}