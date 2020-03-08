using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Trigger2D : BaseTrigger
{
    [Header("Settings")]
    public bool orientationTrigger = false;
    public string[] collideTags;

#if UNITY_EDITOR
    private string m_currentCollider;
#endif

    public Color gizmoColor = Color.red;

    private void Reset()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;

        collideTags = new string[1] { "GameController" };
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
#if UNITY_EDITOR
        m_currentCollider = other.name;
#endif

        if (!CheckCollideTag(other))
            return;

        if (!orientationTrigger)
            TriggerEnterEvent();
    }


    private void OnTriggerExit2D(Collider2D other)
    {
#if UNITY_EDITOR
        m_currentCollider = other.name;
#endif

        if (!CheckCollideTag(other))
            return;

        if (orientationTrigger)
        {
            float angle = Vector3.Angle(transform.forward, transform.position - other.transform.position);
            if (angle >= 90f)
                TriggerEnterEvent();
            else
                TriggerExitEvent();
        }
        else
            TriggerExitEvent();
    }


    private bool CheckCollideTag(Collider2D other)
    {
        if (collideTags.Length == 0)
            return true;

        for (int i = 0; i < collideTags.Length; i++)
        {
            if (other.tag == collideTags[i])
                return true;
        }

        return false;
    }

#if UNITY_EDITOR
    protected override void OnTriggerEnterCustom()
    {
        //Debug.LogFormat("{0} enter trigger <{1}>", m_currentCollider, name);
    }

    protected override void OnTriggerExitCustom()
    {
        //Debug.LogFormat("{0} exit trigger <{1}>", m_currentCollider, name);
    }

    private void OnDrawGizmos()
    {
        DrawCube(0.1f);
    }

    private void OnDrawGizmosSelected()
    {
        DrawCube(0.3f);
    }

    BoxCollider2D gizmoBoxCollider;
    CircleCollider2D gizmoSphereCollider;
    private void DrawCube(float alpha)
    {
        if (gizmoBoxCollider == null && gizmoSphereCollider == null)
        {
            gizmoBoxCollider = GetComponent<BoxCollider2D>();
            gizmoSphereCollider = GetComponent<CircleCollider2D>();
        }

        Matrix4x4 matrixCopy = Gizmos.matrix;
        Vector3 colliderScale = Vector3.one;


        Color colorCopy = Gizmos.color;
        Color color = gizmoColor;
        color.a *= alpha;
        Gizmos.color = color;

        if (gizmoBoxCollider != null)
        {
            colliderScale = new Vector2(transform.lossyScale.x * gizmoBoxCollider.size.x, transform.lossyScale.y * gizmoBoxCollider.size.y);
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, colliderScale);
            Gizmos.DrawCube(Vector3.zero, Vector3.one);

        }
        else if (gizmoSphereCollider != null)
        {
            colliderScale = transform.lossyScale * gizmoSphereCollider.radius;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, colliderScale);
            Gizmos.DrawSphere(Vector3.zero, 1);
        }






        Gizmos.color = colorCopy;
        Gizmos.matrix = matrixCopy;
    }
#endif
}
