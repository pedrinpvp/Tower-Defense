// A short example of Vector3.Lerp usage.
// Add it to an object in your scene, and at Play time it will draw in the Scene View a small yellow line between the scene origin, and a position interpolated between two other positions (one on the up axis, one on the forward axis).

using UnityEngine;
public class ExampleClass : MonoBehaviour
{
    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    void Update()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        Vector3 interpolatedPosition = Vector3.Lerp(Vector3.up, Vector3.forward, interpolationRatio);

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)

        Debug.DrawLine(Vector3.zero, Vector3.up, Color.green);
        Debug.DrawLine(Vector3.zero, Vector3.forward, Color.blue);
        Debug.DrawLine(Vector3.zero, interpolatedPosition, Color.yellow);
    }
}