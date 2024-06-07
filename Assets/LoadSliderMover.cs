using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoadSliderMover : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    public async Task Load(Queue<ILoadingOperation> loadingOperations)
    {
        int loadingOperationsCount = loadingOperations.Count;
        int i = 0;
        
        foreach (ILoadingOperation loadingOperation in loadingOperations)
        {
            await loadingOperation.Load();
            _slider.value += 1f / loadingOperationsCount;
            i++;
        }
    }
}
