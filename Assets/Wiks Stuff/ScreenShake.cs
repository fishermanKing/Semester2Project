using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float minRange = -0.1f;
    [SerializeField] private float maxRange = 0.1f;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 initialPos = transform.localPosition;
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(minRange, maxRange) * magnitude;
            float y = Random.Range(minRange, maxRange) * magnitude;

            transform.localPosition = new Vector3(x, y, initialPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = initialPos;
    }
}
