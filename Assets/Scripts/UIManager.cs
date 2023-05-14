using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Interfaces;
using Events;

public sealed class UIManager : MonoBehaviour
{
    [SerializeField] Text _missedRecyclingObjects;

    [SerializeField] Text _plasticPointsText;
    [SerializeField] Text _canPointsText;
    [SerializeField] Text _paperPointsText;

    [SerializeField] GameObject _grabAction;

    int _missedRecyclingObjectsCount = 0;
    int _plasticPoints = 0;
    int _canPoints = 0;
    int _paperPoints = 0;

    private void Start()
    {

    }


    void AddMissedRecyclingObject()
    {
        Debug.Log($"Destroy{this}");
        _missedRecyclingObjectsCount += 1;
        _missedRecyclingObjects.text = $"MISSED: {_missedRecyclingObjectsCount}";
    }

    void AddPlasticCount()
    {
        _plasticPoints += 1;
        _plasticPointsText.text = $"PLASTIC: {_plasticPoints}";
    }
    void AddPaperCount()
    {
        _paperPoints += 1;
        _paperPointsText.text = $"PAPER: {_paperPoints}";
    }
    void AddCanCount()
    {
        _canPoints += 1;
        _canPointsText.text = $"CAN: {_canPoints}";
    }

    void ToggleGrabAction(bool isEnable) => _grabAction.SetActive(isEnable ? true : false);

    private void OnEnable()
    {
        GameEvents.OnMissedObjectCountChanged.AddListener(AddMissedRecyclingObject);
        GameEvents.OnPlasticPointsChanged.AddListener(AddPlasticCount);
        GameEvents.OnCanPointsChanged.AddListener(AddCanCount);
        GameEvents.OnPaperPointsChanged.AddListener(AddPaperCount);
        GameEvents.ToggleGrabAction.AddListener(ToggleGrabAction);
    }

    private void OnDisable()
    {
        GameEvents.OnMissedObjectCountChanged.RemoveListener(AddMissedRecyclingObject);
        GameEvents.OnPlasticPointsChanged.RemoveListener(AddPlasticCount);
        GameEvents.OnCanPointsChanged.RemoveListener(AddCanCount);
        GameEvents.OnPaperPointsChanged.RemoveListener(AddPaperCount);
        GameEvents.ToggleGrabAction.RemoveListener(ToggleGrabAction);
    }
}
