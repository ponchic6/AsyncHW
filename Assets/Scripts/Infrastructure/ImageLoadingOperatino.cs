using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ImageLoadingOperatino : ILoadingOperation
{
    private string imageUrl = "https://avatars.dzeninfra.ru/get-zen_doc/1930013/pub_5dac34675eb26800aee1440a_5dac39245d6c4b00b025198b/scale_1200";
    private Texture2D _texture;
    public Texture2D Texture => _texture;

    public async Task Load()
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            var operation = request.SendWebRequest();

            while (!operation.isDone)
            {   
                Debug.Log("Жду картинку");
                await Task.Yield();
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("Картинку получил");
                _texture = DownloadHandlerTexture.GetContent(request);
            }
        }
    }
}