using UnityEngine; // Подключение библиотеки UnityEngine, которая предоставляет доступ к компонентам Unity, таким как Transform и Quaternion.

public class DirectionalRotator // Определение класса DirectionalRotator, который отвечает за вращение объекта в заданном направлении.
{
    private Transform _transform; // Поле для хранения ссылки на Transform объекта, который будет вращаться.
    private float _rotationSpeed; // Поле для хранения скорости вращения объекта.
    private Vector3 _currentDirection; // Поле для хранения текущего направления вращения.

    // Конструктор класса DirectionalRotator. Принимает Transform объекта и скорость вращения.
    public DirectionalRotator(Transform transform, float rotationSpeed)
    {
        _transform = transform; // Инициализация поля _transform переданным Transform.
        _rotationSpeed = rotationSpeed; // Инициализация поля _rotationSpeed переданным значением скорости вращения.
    }

    // Метод для установки нового направления вращения.
    public void SetInputDirection(Vector3 direction)
    {
        _currentDirection = direction; // Сохраняет переданное направление в поле _currentDirection.
    }

    // Свойство для получения текущей ориентации объекта (его Quaternion).
    public Quaternion CurrentRotation => _transform.rotation;

    // Метод, который обновляет вращение объекта. Вызывается каждый кадр.
    public void Update(float deltaTime)
    {
        // Если длина вектора направления меньше 0.05, вращение не выполняется.
        if (_currentDirection.magnitude < 0.05f)
            return;

        // Создаёт Quaternion, который представляет поворот в направлении _currentDirection.
        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);

        // Рассчитывает шаг вращения на основе скорости и времени, прошедшего с последнего кадра.
        float step = _rotationSpeed * deltaTime;

        // Плавно вращает объект от текущей ориентации к целевой ориентации (lookRotation).
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}
