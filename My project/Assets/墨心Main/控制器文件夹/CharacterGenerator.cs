
using UnityEngine;
namespace 墨心main // 添加命名空间
{
    public class CharacterGenerator
    {
        // 静态字段，供所有角色生成器实例共享
        public static Camera mainCamera = Camera.main; // 直接初始化为主摄像机
        public static string spritePath = "player1"; // 将 player1 作为字符串

        private GameObject characterObject; // 新创建的GameObject
        private float moveSpeed = 5f; // 移动速度
        private float Speed = 5f;//旋转速度
        private float cameraOffsetZ = -10f; // 摄像机与角色的Z轴偏移
        private AudioSource moveSound; // 声明 AudioSource

        public CharacterGenerator(Vector3 startPosition, float sortingOrder)
        {
            // 从 Resources 文件夹加载 Sprite
            Sprite characterSprite = Resources.Load<Sprite>(spritePath); // 确保路径正确

            // 确保 Sprite 加载成功
            if (characterSprite != null)
            {
                // 创建一个新的 GameObject
                characterObject = new GameObject("Character");

                // 添加 SpriteRenderer 组件
                SpriteRenderer spriteRenderer = characterObject.AddComponent<SpriteRenderer>();

                // 设置 SpriteRenderer 的 sprite 属性
                spriteRenderer.sprite = characterSprite;

                // 设置图层顺序，确保角色在地图之上
                spriteRenderer.sortingOrder = (int)sortingOrder;

                // 将角色位置设置在可见范围内
                characterObject.transform.position = startPosition;

                Debug.Log("人物图片加载成功，已设置为 GameObject！");
            }
            else
            {
                Debug.LogError("未能加载人物图片，检查文件名和路径。");
            }
        }

        public void AddAudioSource()
        {
            // 确保角色对象存在
            if (characterObject != null)
            {
                // 添加 AudioSource 组件
                moveSound = characterObject.AddComponent<AudioSource>();

                // 从 Resources 中加载音效文件
                AudioClip moveClip = Resources.Load<AudioClip>("移动"); // 确保文件名正确

                // 确保音效文件加载成功
                if (moveClip != null)
                {
                    // 设置音效文件
                    moveSound.clip = moveClip;
                    moveSound.loop = false; // 设置为不循环播放

                    Debug.Log("音效组件已成功添加到角色！");
                }
                else
                {
                    Debug.LogError("未能加载音效文件，检查文件名和路径。");
                }
            }
            else
            {
                Debug.LogError("角色对象不存在，无法添加 AudioSource 组件。");
            }
        }

        public void MoveCharacter()
        {
            if (characterObject != null)
            {
                // 标记角色是否在移动
                bool isMoving = false;

                // 检查按键并移动
                if (Input.GetKey(KeyCode.A))
                {
                    characterObject.transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
                    isMoving = true;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    characterObject.transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
                    isMoving = true;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    characterObject.transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                    isMoving = true;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    characterObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
                    isMoving = true;
                }

                // 播放音效
                if (isMoving && moveSound != null && !moveSound.isPlaying)
                {
                    moveSound.Play(); // 播放音效
                }
                else if (!isMoving && moveSound != null && moveSound.isPlaying)
                {
                    moveSound.Stop(); // 停止音效
                }

                // 检测按下 Shift 键加速
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    moveSpeed = 15f; // 设置为冲刺速度
                }
                else
                {
                    moveSpeed = 5f; // 恢复为默认速度
                }
            }
            characterObject.transform.position = new Vector3(Mathf.Clamp(characterObject.transform.position.x, -4, 93), Mathf.Clamp(characterObject.transform.position.y, -4, 93), 0);

        }

        public void HandleRotation()
        {
            // 处理角色旋转
            if (Input.GetKey(KeyCode.W))
            {
                characterObject.transform.rotation = Quaternion.Lerp(characterObject.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                characterObject.transform.rotation = Quaternion.Lerp(characterObject.transform.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                characterObject.transform.rotation = Quaternion.Lerp(characterObject.transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                characterObject.transform.rotation = Quaternion.Lerp(characterObject.transform.rotation, Quaternion.Euler(0, 0, 270), Time.deltaTime * Speed);
            }
        }


        // 摄像机跟随方法
        public void FollowCharacter()
        {
            if (characterObject != null && mainCamera != null)
            {
                // 让摄像机跟随角色
                mainCamera.transform.position = new Vector3(characterObject.transform.position.x, characterObject.transform.position.y, cameraOffsetZ);
            }
            else
            {
                Debug.LogError("摄像机或角色对象未正确初始化");
            }
        }

        // 返回角色对象
        public GameObject GetCharacterObject()
        {
            return characterObject;
        }
    }
}

