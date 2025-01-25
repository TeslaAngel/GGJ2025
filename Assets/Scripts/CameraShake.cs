using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 ogLocalEulerAngles;

    void Start()
    {
        ogLocalEulerAngles = transform.localEulerAngles;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float y = Random.Range(-10f, 10f) * magnitude;

            transform.localEulerAngles = new Vector3(ogLocalEulerAngles.x, y, ogLocalEulerAngles.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.localEulerAngles = ogLocalEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            StartCoroutine(Shake(0.15f, 0.4f));
        }    
    }
}
