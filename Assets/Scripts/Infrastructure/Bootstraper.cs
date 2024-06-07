using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private LoadSliderMover _loadSliderMover;

    private async void Start()
    {
        Queue<ILoadingOperation> loadingOperations = new Queue<ILoadingOperation>();
        
        QuadLoadingOperation quadLoadingOperation = new QuadLoadingOperation();
        ImageLoadingOperatino imageLoadingOperatino = new ImageLoadingOperatino();
        
        loadingOperations.Enqueue(imageLoadingOperatino);
        loadingOperations.Enqueue(quadLoadingOperation);
        loadingOperations.Enqueue(new LoadSceneOperation(imageLoadingOperatino, quadLoadingOperation));
        await _loadSliderMover.Load(loadingOperations);
    }
}