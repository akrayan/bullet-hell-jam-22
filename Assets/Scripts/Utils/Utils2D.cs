using UnityEngine;

public class Utils2D
{
    static public void TransformFilpY(Transform transform) {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, -1, 1));
    }

    static public void LookAt2D(Transform transform, Vector3 pos) {
        Vector3 dir = pos - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}