using UnityEngine;
namespace 墨心main // 添加命名空间
{
    public class TileClickHandler : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private string currentTileType; // 记录当前地块类型

        private Texture2D digCursor; // 挖掘光标的纹理
        private Texture2D regularCursor; // 常规光标的纹理

        private AudioSource audioSource; // 音频源
        public AudioClip miningSound; // 开采音效

        private GameObject floatingItem; // 跳币的 GameObject

        // 事件
        public delegate void TileClicked(string tileType);
        public static event TileClicked OnTileClicked;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            currentTileType = spriteRenderer.sprite.name; // 记录当前地块类型（如"stone"或"desert"）

            LoadCursors(); // 加载光标纹理

            // 添加音频源组件
            audioSource = gameObject.AddComponent<AudioSource>();

            // 加载开采音效
            miningSound = Resources.Load<AudioClip>("开采"); // 确保音效文件名与路径正确
            if (miningSound == null)
            {
                Debug.LogError("未能加载音效，请确保路径正确并且文件存在。");
            }
        }

        private void LoadCursors()
        {
            // 从 Resources 文件夹加载光标纹理
            digCursor = Resources.Load<Texture2D>("挖掘光标"); // 挖掘光标的名称
            regularCursor = Resources.Load<Texture2D>("常规光标"); // 常规光标的名称

            if (digCursor == null || regularCursor == null)
            {
                Debug.LogError("未能加载光标纹理，请确保路径正确并且文件存在。");
            }
        }

        private void OnMouseEnter()
        {
            // 根据当前地块类型更改光标
            if (currentTileType == "stone") // 如果是矿石
            {
                Cursor.SetCursor(digCursor, Vector2.zero, CursorMode.Auto); // 设置挖掘光标
            }
            else
            {
                Cursor.SetCursor(regularCursor, Vector2.zero, CursorMode.Auto); // 设置常规光标
            }
        }

        private void OnMouseExit()
        {
            // 鼠标离开时恢复默认光标
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // 恢复默认光标
        }

        private void OnMouseDown() // 当鼠标点击该对象时调用
        {
            if (currentTileType == "stone") // 检查当前地块类型
            {
                ReplaceTileSprite("desert"); // 将地块替换为沙漠
                InventoryManager.Instance.AddItem(new Item("Inventorystone", "Assets/Resources/Inventorystone.png"));
                PlayMiningSound(); // 播放开采音效
                ShowFloatingItem(); // 显示跳币

                // 触发事件
                OnTileClicked?.Invoke("stone"); // 触发点击地块事件，传递地块类型
            }
            else if (currentTileType == "desert") // 如果当前地块是沙漠
            {
                Debug.Log("当前地块已经是沙漠，无需替换。");
            }
        }

        private void PlayMiningSound()
        {
            // 播放开采音效
            if (miningSound != null)
            {
                audioSource.PlayOneShot(miningSound);
            }
        }

        private void ReplaceTileSprite(string newTileType)
        {
            // 加载新的地块图片
            Sprite newSprite = Resources.Load<Sprite>(newTileType); // 确保新图片在Assets/Resources中
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;  // 替换图片
                currentTileType = newTileType; // 更新当前地块类型为新类型
                Debug.Log("已替换地块：" + gameObject.name + " 的图片为：" + newTileType);
            }
            else
            {
                Debug.LogError("未能加载新的地块图片，检查文件名和路径。");
            }
        }

        private void ShowFloatingItem()
        {
            // 创建跳币
            floatingItem = new GameObject("FloatingItem");
            SpriteRenderer itemRenderer = floatingItem.AddComponent<SpriteRenderer>();
            itemRenderer.sprite = Resources.Load<Sprite>("Inventorystone"); // 确保漂浮资源的路径正确

            // 设置跳币的图层
            itemRenderer.sortingLayerName = "Default"; // 设置为默认图层（可根据需要更改）
            itemRenderer.sortingOrder = 1; // 设置图层顺序为1

            // 设置跳币的位置在鼠标点击位置上方
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0; // 确保在2D平面上
            floatingItem.transform.position = mouseWorldPosition + new Vector3(0, 0.5f, 0); // 上移一点

            // 启动漂浮效果
            StartFloatingEffect();
        }

        private void StartFloatingEffect()
        {
            // 启动漂浮物体上升的逻辑
            float floatHeight = 1f; // 漂浮的高度
            float floatSpeed = 2f; // 漂浮的速度
            float lifeTime = 1f; // 漂浮物体的生存时间

            // 使用 Update 方法来控制漂浮效果
            StartCoroutine(FloatingCoroutine(floatHeight, floatSpeed, lifeTime));
        }

        private System.Collections.IEnumerator FloatingCoroutine(float floatHeight, float floatSpeed, float lifeTime)
        {
            float elapsedTime = 0f;
            Vector3 startPosition = floatingItem.transform.position;
            Vector3 targetPosition = startPosition + new Vector3(0, floatHeight, 0);

            while (elapsedTime < lifeTime)
            {
                // 计算当前的高度
                float t = (elapsedTime / lifeTime);
                floatingItem.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null; // 等待下一帧
            }

            // 在漂浮结束后销毁物体
            Destroy(floatingItem);
        }
    }
}