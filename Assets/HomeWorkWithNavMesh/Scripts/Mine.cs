using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _exploisonRadius;
    [SerializeField] private float _timeUntilExploison;
    [SerializeField] private int _damage;
    [SerializeField] private SphereCollider _triggerCollider;
    [SerializeField] private GameObject _explosionEffectPrefab;
    

    private Coroutine _detonateProcess;

    private bool _isInit;
    public bool InDetonateProcess => _detonateProcess != null;


    public void Initialize(float explosionRadius, float timeUntilExplosion, int damage)
    {
        _exploisonRadius = explosionRadius;
        _timeUntilExploison = timeUntilExplosion;
        _damage = damage;

        _triggerCollider.radius = _exploisonRadius;

        _isInit = true;
    }

    private void Awake()
    {
        _triggerCollider.radius = _exploisonRadius;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(_isInit == false)
            return;

        if (InDetonateProcess)
            return;

        if (other.TryGetComponent(out IDamageable damageable))
            _detonateProcess = StartCoroutine(DetonateProcess());

    }
    private IEnumerator DetonateProcess()
    {
        float time = _timeUntilExploison;

        while (time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log($"Time until explosion: {time}");
            yield return null;
        }

        Explode(); // <-- Вызов взрыва

        _detonateProcess = null;
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.3f, 0.1f, 0.3f); // Полупрозрачный красный
        Gizmos.DrawSphere(transform.position, _exploisonRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _exploisonRadius);
    }

    private void Explode()
    {
        if (_explosionEffectPrefab != null)
        {
            GameObject effect = Instantiate(_explosionEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 3f); // Уничтожить эффект через 3 секунды (или по длительности эффекта)
        }


        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, _exploisonRadius);


        foreach (var collider in detectedColliders)
        {
            if (collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }
        }

        // Логика взрыва мины
    }

}
