
using UnityEngine;

public class BgScript : MonoBehaviour
{
    MeshRenderer meshRenderer;
    private Vector2 texturePos;
    [SerializeField] private float speed;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        texturePos = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        MoveTexture();
    }
    private void MoveTexture()
    {
        texturePos = new Vector2(texturePos.x + speed * Time.deltaTime , texturePos.y);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex"  , texturePos);   
    }
}
