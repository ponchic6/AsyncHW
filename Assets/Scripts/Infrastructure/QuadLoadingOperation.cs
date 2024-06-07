using System.Threading.Tasks;
using UnityEngine;

public class QuadLoadingOperation : ILoadingOperation
{
    private GameObject _quadPrefab;
    public GameObject QuadPrefab => _quadPrefab;

    public async Task Load()
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<GameObject>("Quad");

        while (!resourceRequest.isDone)
        {
            await Task.Yield();
        }

        _quadPrefab = (GameObject)resourceRequest.asset;
    }
}