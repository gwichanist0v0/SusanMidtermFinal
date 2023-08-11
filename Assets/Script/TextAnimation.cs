using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float blinkInterval = 0.5f; 

    private void Start()
    {
    
        StartBlinking();
    }

    private void StartBlinking()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            textMesh.enabled = !textMesh.enabled;

            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
