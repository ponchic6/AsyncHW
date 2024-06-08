using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class QuadAnimationController : MonoBehaviour
{
    private float _targetRotation;
    
    public async Task StartRotation(CancellationToken cancellationToken)
    {
        _targetRotation = 90f;
        float currentRotation = 0f;
        
        while (currentRotation < _targetRotation)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                transform.eulerAngles = new Vector3(0, 0, _targetRotation);
                break;
            }

            currentRotation += Time.deltaTime * 5;
            transform.Rotate(transform.forward, Time.deltaTime * 5);
            await Task.Yield();
        }
    }
}
