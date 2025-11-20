using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopView : MonoBehaviour
{
    [Header("List")]
    public Transform itemsParent;
    public GameObject itemPrefab;

    [Header("Global Buy Button")]
    public Button buyButton;
}