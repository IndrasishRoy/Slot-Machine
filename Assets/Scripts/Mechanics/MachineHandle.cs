using System.Collections;
using UnityEngine;

public class MachineHandle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SlotMachineManager slotMachineManager;
    [SerializeField] GameObject handleUp, handleDown;
    
    private void OnMouseDown()
    {
        if (!slotMachineManager.isSpining)
        {
            StartCoroutine(StartMachine());
        }
    }

    IEnumerator StartMachine()
    {
        SetHandle(1);

        yield return new WaitForSeconds(0.25f);

        slotMachineManager.StartSpin();
        SetHandle(0);
    }

    void SetHandle(int index)
    {
        switch (index)
        {
            case 0:
                handleUp.SetActive(true);
                handleDown.SetActive(false);
                break;
            case 1:
                handleUp.SetActive(false);
                handleDown.SetActive(true);
                break;
        }
    }
}
