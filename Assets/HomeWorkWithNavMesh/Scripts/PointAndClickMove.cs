using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PointAndClickMove : MonoBehaviour
{
    [SerializeField] private LayerMask _clickableLayers = ~0;

    [SerializeField] private GameObject _clickMarkerPrefab; // Префаб маркера
    [SerializeField] private float _markerFadeTime = 0.7f;

    private NavMeshAgent _agent;
    private DirectionalRotator _rotator;
    [SerializeField] private float _rotationSpeed;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false; // Отключаем автоматическое вращение

        _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);
        if (_agent == null)
            Debug.LogError("NavMeshAgent component not found!", this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _clickableLayers))
            {
                _agent.SetDestination(hit.point);
                ShowClickMarker(hit.point, hit.normal);

            }
        }

        if (_agent.hasPath && _agent.velocity.sqrMagnitude > 0.01f)
        {
            _rotator.SetInputDirection(_agent.velocity.normalized);
            _rotator.Update(Time.deltaTime);
        }
    }
    


    private void ShowClickMarker(Vector3 position, Vector3 normal)
    {
        if (_clickMarkerPrefab == null) return;
        // Вращаем маркер так, чтобы его "верх" совпадал с нормалью поверхности
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);
        GameObject marker = Instantiate(_clickMarkerPrefab, position + normal * 0.05f, rotation);
        StartCoroutine(FadeAndDestroy(marker, _markerFadeTime));
    }

    private IEnumerator FadeAndDestroy(GameObject marker, float fadeTime)
    {
        float t = 0f;
        var renderers = marker.GetComponentsInChildren<Renderer>();
        Color[] startColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
            startColors[i] = renderers[i].material.color;

        while (t < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeTime);
            for (int i = 0; i < renderers.Length; i++)
            {
                Color c = startColors[i];
                c.a = alpha;
                renderers[i].material.color = c;
            }
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(marker);
    }
}