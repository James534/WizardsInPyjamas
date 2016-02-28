using UnityEngine;
using System.Collections;

public class OrbSpin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(150 * Time.deltaTime, 200 * Time.deltaTime, 100 * Time.deltaTime);
    }
}