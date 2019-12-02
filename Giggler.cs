using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Giggler : MonoBehaviour
{
    [Tooltip("Time to wait before starting the giggles!")]
    public float timeOffset;
    [Header("scale")]
    [Tooltip("Time in seconds between two scales")]
    public float scaleTime;
    [Tooltip("Amplitude to apply to the scale of the transform at start")]
    public float scaleAmplitude;
    [Header("x axis")]
    [Tooltip("Time in seconds between two x axis transformations")]
    public float xTime;
    [Tooltip("Amplitude to apply to x axis of the transform at start")]
    public float xAmplitude;
    [Header("y axis")]
    [Tooltip("Timein seconds between two y axis transformations")]
    public float yTime;
    [Tooltip("Amplitude to apply to the y axis of the transform at start")]
    public float yAmplitude;

    private Giggle giggleScale;
    private Giggle giggleX;
    private Giggle giggleY;

    void Start()
    {
        this.giggleScale = new Giggle(this.scaleTime, this.scaleAmplitude, this.transform.localScale.x, this.timeOffset);
        this.giggleX = new Giggle(this.xTime, this.xAmplitude, this.transform.position.x, this.timeOffset);
        this.giggleY = new Giggle(this.yTime, this.yAmplitude, this.transform.position.y, this.timeOffset);
    }

    void Update()
    {
        this.transform.localScale = Vector2.one * this.giggleScale.GetNextValue(this.transform.localScale.x);
        Vector2 position = this.transform.position;
        position.x = this.giggleX.GetNextValue(position.x);
        position.y = this.giggleY.GetNextValue(position.y);
        this.transform.position = position;
    }
}
