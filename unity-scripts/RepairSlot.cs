using UnityEngine;

public class RepairSlot : MonoBehaviour
{
    [SerializeField]
    private PartType expectedType = PartType.Fuse;

    [SerializeField]
    private Transform snapPoint;

    public bool IsFilled { get; private set; }

    public PartType ExpectedType => expectedType;

    public Vector3 SnapWorldPosition => snapPoint != null ? snapPoint.position : transform.position;

    public bool CanAccept(PartDraggable part)
    {
        return !IsFilled && part != null && part.Type == expectedType;
    }

    public void Occupy(PartDraggable part)
    {
        if (IsFilled || part == null)
        {
            return;
        }

        IsFilled = true;
        var target = snapPoint != null ? snapPoint : transform;
        part.transform.position = target.position;
    }
}