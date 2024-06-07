using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOperation : ILoadingOperation
{
    private readonly ImageLoadingOperatino _imageLoadingOperatino;
    private readonly QuadLoadingOperation _quadLoadingOperation;

    public LoadSceneOperation(ImageLoadingOperatino imageLoadingOperatino, QuadLoadingOperation quadLoadingOperation)
    {
        _imageLoadingOperatino = imageLoadingOperatino;
        _quadLoadingOperation = quadLoadingOperation;
    }

    public async Task Load()
    {
        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync("MainScene");

        while (!loadSceneAsync.isDone)
        {
            await Task.Yield();
        }

        GameObject quad = Object.Instantiate(_quadLoadingOperation.QuadPrefab);
        quad.GetComponent<MeshRenderer>().material.mainTexture = _imageLoadingOperatino.Texture;
    }
}