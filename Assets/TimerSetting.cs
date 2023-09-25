using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class TimerSetting : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _startPos, _endPos;
    [SerializeField] private TextMeshProUGUI _timeTMP;

    private float _timeCount;
    private bool _isOn;

    private void Start()
    {
        GameManager.SetTimeStop += OnSetTimer;
        Hide();
    }

    private void OnSetTimer(float timer)
    {
        _timeCount = timer;
        Debug.Log($"Timer Start : {timer}");
        Show();
    }

    [Button]
    private void Show()
    {
        _isOn = true;
        _rectTransform.anchoredPosition = new Vector2(0, _startPos);
        _rectTransform.DOAnchorPosY(_endPos, 0.5f);
    }

    private void Hide()
    {
        _rectTransform.anchoredPosition = new Vector2(0, _endPos);
        _rectTransform.DOAnchorPosY(_startPos, 0.5f);
    }

    private void FixedUpdate()
    {
        if (_isOn)
        {
            if (_timeCount > 0)
            {
                _timeCount -= Time.fixedDeltaTime;
                SetTime();
            }
            else
            {
                _isOn = false;
                Hide();
                AudioManager.Instance.Stop();
                _timeTMP.SetText("END !!!");
            }
        }
    }

    private void SetTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(_timeCount);
        string timeText = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        _timeTMP.SetText(timeText);
    }
}