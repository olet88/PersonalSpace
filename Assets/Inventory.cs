using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int bandages = 0;
    public TextMeshPro bandageText;

    public void AddBandageToInventory()
    {
        bandages = bandages + 1;
        bandageText.text = "bandages: " + bandages; 
    }
}
