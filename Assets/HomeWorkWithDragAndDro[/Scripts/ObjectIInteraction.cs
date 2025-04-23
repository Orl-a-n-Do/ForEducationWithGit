using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Camera mainCamera;

    private IDraggable selectedDraggable;

    void Update()
    {
       Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                selectedDraggable = hit.collider.GetComponent<IDraggable>();
                if (selectedDraggable != null)
                {
                    Debug.Log("Есть Соприкосновение");
                    selectedDraggable.OnDragStart(hit.point);
                }
            }
        }

        if (Input.GetMouseButton(0) && selectedDraggable != null) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                selectedDraggable.OnDrag(hit.point);
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedDraggable != null) 
        {
            selectedDraggable.OnDragEnd();
            selectedDraggable = null;
        }
    }
}
