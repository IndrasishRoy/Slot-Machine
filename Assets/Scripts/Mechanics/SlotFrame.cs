using System;
using System.Collections;
using UnityEngine;

public class SlotFrame : MonoBehaviour
{
    [Header("Settings")]
    public SlotSymbol ChoosenSymbol;
    public GameObject Row;
    public float downMovementAmt = 0.15f;
    public float movementInterval = 0.3f;
    public bool isSpinning = true;
    public float distance = 0.3f; 
    public SymbolMarkEnum symbolMark;
    public Action<SymbolMarkEnum> GottenSpin;

    [ContextMenu("Run Test Method")]
    public void CenterAlignSymbol()
    {
        isSpinning = false;
        StartCoroutine(CenterAlignSymbolCO());
    }

    IEnumerator CenterAlignSymbolCO()
    {
        yield return new WaitForSeconds(0.05f);

        if (Row == null)
        {
            Debug.LogError("Row not assigned!");
            yield break;
        }

        //Find closest symbol to frame center
        SlotSymbol[] symbols = Row.GetComponentsInChildren<SlotSymbol>();

        float closestDistance = float.MaxValue;
        SlotSymbol closestSymbol = null;

        foreach (var symbol in symbols)
        {
            float dist = Mathf.Abs(symbol.transform.position.y - transform.position.y);

            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestSymbol = symbol;
            }
        }

        if (closestSymbol == null)
        {
            Debug.LogError("No symbol found!");
            yield break;
        }

        //Calculate alignment offset
        float offset = closestSymbol.transform.position.y - transform.position.y;

        Vector3 startPos = Row.transform.position;
        Vector3 targetPos = startPos - new Vector3(0, offset, 0);

        //Smooth Ease-Out Alignment
        float duration = 0.25f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            //Ease-Out Cubic
            t = 1f - Mathf.Pow(1f - t, 3f);

            Row.transform.position = Vector3.Lerp(startPos, targetPos, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        Row.transform.position = targetPos;

        //Small bounce effect
        Vector3 overshootPos = targetPos - new Vector3(0, 0.05f, 0);

        float bounceDuration = 0.08f;

        elapsed = 0f;
        while (elapsed < bounceDuration)
        {
            Row.transform.position = Vector3.Lerp(targetPos, overshootPos, elapsed / bounceDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0f;
        while (elapsed < bounceDuration)
        {
            Row.transform.position = Vector3.Lerp(overshootPos, targetPos, elapsed / bounceDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Row.transform.position = targetPos;

        //Final result
        symbolMark = closestSymbol.symbolMarkEnum;
        GottenSpin?.Invoke(symbolMark);
    }
}
