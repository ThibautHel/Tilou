using System;
using UnityEditor;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [Range(0f, 60f)]
    public float Seconds = 0;
    public float tickSize;
    public bool Smooth;

    private void OnDrawGizmos()
    {
        Handles.matrix = Gizmos.matrix = transform.localToWorldMatrix;
        Handles.DrawWireDisc(Vector3.zero, Vector3.forward, 1);

        for (int i = 0; i < 60; i++)
        {
            Vector2 dir = SecondToDir(i);
            DrawTick(dir, tickSize, 1);
        }

        for (int i = 0; i < 12; i++)
        {
            Vector2 dir = HoursToDir(i);
            DrawTick(dir, tickSize, 3);
        }
        DateTime time = DateTime.Now;
        float seconds = time.Second;
        if(Smooth)
        {
            seconds += time.Millisecond / 1000f;
        }
        DrawClockHandle(SecondToDir(seconds), 0.9f, 1f, Color.red);
        DrawClockHandle(SecondToDir(time.Minute), 0.7f, 2f, Color.yellow);
        DrawClockHandle(HoursToDir(time.Hour), 0.9f, 2f, Color.white);
    }

    void DrawClockHandle(Vector2 dir, float length, float thickness, Color color)
    {
        using(new Handles.DrawingScope(color))
        Handles.DrawLine(default, dir * length, thickness);
    }

    private void DrawTick(Vector2 dir, float length, float thickness)
    {
        Handles.DrawLine(dir, dir * (1 - length), thickness);
    }

    private Vector2 SecondToDir(float seconds) => ValueToDir(seconds, 60);
    private Vector2 HoursToDir(float hours) => ValueToDir(hours, 12);

    private Vector2 ValueToDir(float value, float maxValue)
    {
        float t = value / maxValue;
        return FractionToClockDir(t);
    }

    private Vector2 FractionToClockDir(float t)
    {
        float angleRad = (0.25f - t) * (2 * Mathf.PI);
        return AngleToDir(angleRad);
    }

    private Vector2 AngleToDir(float angleRad)
    {
        return new Vector2(MathF.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
