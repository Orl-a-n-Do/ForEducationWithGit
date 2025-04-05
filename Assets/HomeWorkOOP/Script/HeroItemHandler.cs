using UnityEngine;

public class HeroItemHandler : MonoBehaviour
{
    private Items _currentItem; // Текущий поднятый предмет

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Было соприкосновение с предметом");
        Items item = other.GetComponent<Items>();
        if (item != null && _currentItem == null) // Поднимаем предмет, если у игрока еще нет предмета
        {
            PickUpItem(item);
        }
    }

    private void Update()
    {
        // Используем предмет при нажатии клавиши (например, "E")
        if (Input.GetKeyDown(KeyCode.E) && _currentItem != null)
        {
            UseItem();
        }
    }

    private void PickUpItem(Items item)
    {
        _currentItem = item; 
        item.transform.SetParent(transform); 

        
        item.transform.localPosition = new Vector3(1, 0, 0); 
        item.transform.localRotation = Quaternion.identity; 

        Debug.Log($"Поднят предмет: {item.name}");
    }

    private void UseItem()
    {
        if(_currentItem != null)
        {
            _currentItem.Use(); // Используем предмет
             _currentItem.PlayParticleEffect();
            Destroy(_currentItem.gameObject); // Уничтожаем предмет
            _currentItem = null; // Очищаем ссылку на предмет
            Debug.Log("Предмет использован и уничтожен");
        }
    }
}