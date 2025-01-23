using UnityEngine;
namespace ī��main // ��������ռ�
{
    public class TileClickHandler : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private string currentTileType; // ��¼��ǰ�ؿ�����

        private Texture2D digCursor; // �ھ��������
        private Texture2D regularCursor; // �����������

        private AudioSource audioSource; // ��ƵԴ
        public AudioClip miningSound; // ������Ч

        private GameObject floatingItem; // ���ҵ� GameObject

        // �¼�
        public delegate void TileClicked(string tileType);
        public static event TileClicked OnTileClicked;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            currentTileType = spriteRenderer.sprite.name; // ��¼��ǰ�ؿ����ͣ���"stone"��"desert"��

            LoadCursors(); // ���ع������

            // �����ƵԴ���
            audioSource = gameObject.AddComponent<AudioSource>();

            // ���ؿ�����Ч
            miningSound = Resources.Load<AudioClip>("����"); // ȷ����Ч�ļ�����·����ȷ
            if (miningSound == null)
            {
                Debug.LogError("δ�ܼ�����Ч����ȷ��·����ȷ�����ļ����ڡ�");
            }
        }

        private void LoadCursors()
        {
            // �� Resources �ļ��м��ع������
            digCursor = Resources.Load<Texture2D>("�ھ���"); // �ھ��������
            regularCursor = Resources.Load<Texture2D>("������"); // �����������

            if (digCursor == null || regularCursor == null)
            {
                Debug.LogError("δ�ܼ��ع��������ȷ��·����ȷ�����ļ����ڡ�");
            }
        }

        private void OnMouseEnter()
        {
            // ���ݵ�ǰ�ؿ����͸��Ĺ��
            if (currentTileType == "stone") // ����ǿ�ʯ
            {
                Cursor.SetCursor(digCursor, Vector2.zero, CursorMode.Auto); // �����ھ���
            }
            else
            {
                Cursor.SetCursor(regularCursor, Vector2.zero, CursorMode.Auto); // ���ó�����
            }
        }

        private void OnMouseExit()
        {
            // ����뿪ʱ�ָ�Ĭ�Ϲ��
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); // �ָ�Ĭ�Ϲ��
        }

        private void OnMouseDown() // ��������ö���ʱ����
        {
            if (currentTileType == "stone") // ��鵱ǰ�ؿ�����
            {
                ReplaceTileSprite("desert"); // ���ؿ��滻ΪɳĮ
                InventoryManager.Instance.AddItem(new Item("Inventorystone", "Assets/Resources/Inventorystone.png"));
                PlayMiningSound(); // ���ſ�����Ч
                ShowFloatingItem(); // ��ʾ����

                // �����¼�
                OnTileClicked?.Invoke("stone"); // ��������ؿ��¼������ݵؿ�����
            }
            else if (currentTileType == "desert") // �����ǰ�ؿ���ɳĮ
            {
                Debug.Log("��ǰ�ؿ��Ѿ���ɳĮ�������滻��");
            }
        }

        private void PlayMiningSound()
        {
            // ���ſ�����Ч
            if (miningSound != null)
            {
                audioSource.PlayOneShot(miningSound);
            }
        }

        private void ReplaceTileSprite(string newTileType)
        {
            // �����µĵؿ�ͼƬ
            Sprite newSprite = Resources.Load<Sprite>(newTileType); // ȷ����ͼƬ��Assets/Resources��
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;  // �滻ͼƬ
                currentTileType = newTileType; // ���µ�ǰ�ؿ�����Ϊ������
                Debug.Log("���滻�ؿ飺" + gameObject.name + " ��ͼƬΪ��" + newTileType);
            }
            else
            {
                Debug.LogError("δ�ܼ����µĵؿ�ͼƬ������ļ�����·����");
            }
        }

        private void ShowFloatingItem()
        {
            // ��������
            floatingItem = new GameObject("FloatingItem");
            SpriteRenderer itemRenderer = floatingItem.AddComponent<SpriteRenderer>();
            itemRenderer.sprite = Resources.Load<Sprite>("Inventorystone"); // ȷ��Ư����Դ��·����ȷ

            // �������ҵ�ͼ��
            itemRenderer.sortingLayerName = "Default"; // ����ΪĬ��ͼ�㣨�ɸ�����Ҫ���ģ�
            itemRenderer.sortingOrder = 1; // ����ͼ��˳��Ϊ1

            // �������ҵ�λ���������λ���Ϸ�
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0; // ȷ����2Dƽ����
            floatingItem.transform.position = mouseWorldPosition + new Vector3(0, 0.5f, 0); // ����һ��

            // ����Ư��Ч��
            StartFloatingEffect();
        }

        private void StartFloatingEffect()
        {
            // ����Ư�������������߼�
            float floatHeight = 1f; // Ư���ĸ߶�
            float floatSpeed = 2f; // Ư�����ٶ�
            float lifeTime = 1f; // Ư�����������ʱ��

            // ʹ�� Update ����������Ư��Ч��
            StartCoroutine(FloatingCoroutine(floatHeight, floatSpeed, lifeTime));
        }

        private System.Collections.IEnumerator FloatingCoroutine(float floatHeight, float floatSpeed, float lifeTime)
        {
            float elapsedTime = 0f;
            Vector3 startPosition = floatingItem.transform.position;
            Vector3 targetPosition = startPosition + new Vector3(0, floatHeight, 0);

            while (elapsedTime < lifeTime)
            {
                // ���㵱ǰ�ĸ߶�
                float t = (elapsedTime / lifeTime);
                floatingItem.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null; // �ȴ���һ֡
            }

            // ��Ư����������������
            Destroy(floatingItem);
        }
    }
}