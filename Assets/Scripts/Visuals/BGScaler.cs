using UnityEngine;

namespace sample.Visuals
{
    public class BGScaler : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _bgSpriteRenderer;
        private void Awake()
        {
            ResizeSpriteToScreen();
        }

        private void ResizeSpriteToScreen()
        {
            var worldScreenHeight = Camera.main.orthographicSize * 2.0;
            var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

            var spriteSize = _bgSpriteRenderer.sprite.bounds;

            var scaleFactor = (float)worldScreenWidth / spriteSize.size.x;

            _bgSpriteRenderer.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        }
    }
}