using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.SizeUpdate += OnSizeUpdate;
    }

    private void OnDisable()
    {
        _tower.SizeUpdate -= OnSizeUpdate;
    }

    private void OnSizeUpdate(int count)
    {
        _sizeView.text = count.ToString();
    }
}
