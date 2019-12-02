using UnityEngine;

public class Giggle
{
    public float time;
    public float amplitude;
    private float start;
    private float next;
    private float startTime;
    private float previous;

    public Giggle(float time, float amplitude, float start, float timeOffset = 0)
    {
        this.time = time;
        this.amplitude = amplitude;

        this.start = start;
        this.next = this.start;
        this.previous = this.next;
        this.startTime = Time.time - this.time + timeOffset;
    }

    public float GetNextValue(float currentValue)
    {
        float total = this.time;
        float current = Time.time - this.startTime;
        float percent = current / total;

        if (percent < 1 && percent >= 0)
        {
            float easePercent = Easings.BackEaseInOut(percent);
            float step = easePercent * (this.next - this.previous);

            return previous + step;
        }

        this.startTime = Time.time;
        this.previous = this.next;
        this.next = Random.Range(this.start - this.amplitude, this.start + this.amplitude);

        return this.GetNextValue(currentValue);
    }
}
