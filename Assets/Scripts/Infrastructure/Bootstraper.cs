using System.Threading;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private QuadAnimationController _quadAnimationController;
    private CancellationTokenSource _cancellationTokenSource;
    
    private float _lastPressTime;
    private float _maxTimeBetweenPresses = 0.5f;
    private int _pressCount;

    private async void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        await _quadAnimationController.StartRotation(_cancellationTokenSource.Token);
        Debug.Log("Вращение завершено");
    }

    private void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float currentTime = Time.time;
            
            if (currentTime - _lastPressTime < _maxTimeBetweenPresses)
            {
                _pressCount++;
            }
            else
            {
                _pressCount = 1;
            }

            _lastPressTime = currentTime;
            
            if (_pressCount == 3)
            {
                _cancellationTokenSource.Cancel();
                _pressCount = 0;
            }
        }
    }
}