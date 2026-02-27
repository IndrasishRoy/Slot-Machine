using System.Collections;
using UnityEngine;

public class RowMover : MonoBehaviour
{
    [Header("Settings")]
    public int symbolsCount;
    public float movementInterval = 0.3f;
    public float downMovementAmt = 0.15f;
    public int initalRotation = 130;
    public int randomMin = 100, randomMax = 130;
    [SerializeField] SlotFrame mySlot;

    /*<-----Internal-Field----->*/
    private int stepsPerSymbol;

    [ContextMenu("Run Test Method")]
    private void Awake()
    {
        stepsPerSymbol = Mathf.RoundToInt(1.7f / downMovementAmt);
    }

    public void MoveRow()
    {
        StartCoroutine(MoveRowCO());
    }

    IEnumerator MoveRowCO()
    {
        for (int i = 0; i < initalRotation; i++)
        {
            Vector3 tempPos = transform.position;
            tempPos.y -= downMovementAmt;
            transform.position = tempPos;

            yield return new WaitForSeconds(movementInterval);
        }

        int randomNumber = RandomNumberGenerator();

        for (int i = 0; i < randomNumber; i++)
        {
            Vector3 tempPos = transform.position;
            tempPos.y -= downMovementAmt;
            transform.position = tempPos;

            yield return new WaitForSeconds(movementInterval);
        }

        mySlot.CenterAlignSymbol();
    }

    int RandomNumberGenerator()
    {
        int randomSymbolIndex = Random.Range(0, symbolsCount);
        int fullRotations = Random.Range(3, 6);

        int totalSymbolsToMove = (fullRotations * symbolsCount) + randomSymbolIndex;

        return totalSymbolsToMove * stepsPerSymbol;
    }
}
