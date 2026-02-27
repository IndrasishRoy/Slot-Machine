using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlotMachineManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<RowMover> rows;
    [SerializeField] SlotFrame[] frames;
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text resultsTxt;
    private List<SymbolMarkEnum> symbolGotten = new List<SymbolMarkEnum>();

    [Header("Settings")]
    [SerializeField] int rewardAmount;
    public bool isSpining;

    /*<-----Internal-Field----->*/
    private bool isWin = false;
    private int score;

    private void Start()
    {
        score = 0;

        foreach (SlotFrame frame in frames)
        {
            frame.GottenSpin += MarkList;
        }
    }

    [ContextMenu("Run Test Method")]
    public void StartSpin()
    {
        symbolGotten.Clear();
        isSpining = true;

        resultsTxt.text = "";

        foreach (var row in rows)
        {
            row.MoveRow();
        }
    }

    public void MarkList(SymbolMarkEnum markEnum)
    {
        symbolGotten.Add(markEnum);
        if (symbolGotten.Count == 3) CheckSymbols();
    }

    void CheckSymbols()
    {
        isWin = ((symbolGotten[0] == symbolGotten[1]) && (symbolGotten[1] == symbolGotten[2])) ? true : false;

        resultsTxt.color = isWin ? Color.green : Color.blue;
        resultsTxt.text = isWin ? "You Win" : "You Lose";

        if (isWin) UpdateScore(rewardAmount);

        symbolGotten.Clear();
        isSpining = false;
    }

    void UpdateScore(int rewardPoint)
    {
        score += rewardPoint;

        scoreTxt.text = $"Score: {score}";
    }
}
