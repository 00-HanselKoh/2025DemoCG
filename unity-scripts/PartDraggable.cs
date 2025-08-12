using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PartDraggable : MonoBehaviour
{
    [SerializeField]
    private PartType type = PartType.Fuse;

    [SerializeField, Min(0f)]
    private float snapThreshold = 1.0f; // world units

    [SerializeField]
    private RepairManager manager;

    private Vector3 originalPosition;
    private bool placed;
    private Vector3 dragOffset;

    public PartType Type => type;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (placed) return;
        var world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        world.z = transform.position.z;
        dragOffset = transform.position - world;
    }

    private void OnMouseDrag()
    {
        if (placed) return;
        var world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        world.z = transform.position.z;
        transform.position = world + dragOffset;
    }

    private void OnMouseUp()
    {
        if (placed) return;

        var slots = FindObjectsOfType<RepairSlot>();
        RepairSlot best = null;
        float bestDist = float.MaxValue;
        Vector3 pos = transform.position;

        foreach (var slot in slots)
        {
            if (!slot.CanAccept(this)) continue;
            float d = Vector2.Distance(pos, slot.SnapWorldPosition);
            if (d < bestDist)
            {
                bestDist = d;
                best = slot;
            }
        }

        if (best != null && bestDist <= snapThreshold)
        {
            best.Occupy(this);
            placed = true;
            if (manager != null) manager.NotifyPartPlaced();
        }
        else
        {
            transform.position = originalPosition;
        }
    }
}