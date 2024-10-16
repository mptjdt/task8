
using UnityEngine;
namespace ī��main // ��������ռ�
{
    public class CharacterGenerator
    {
        // ��̬�ֶΣ������н�ɫ������ʵ������
        public static Camera mainCamera = Camera.main; // ֱ�ӳ�ʼ��Ϊ�������
        public static string spritePath = "player1"; // �� player1 ��Ϊ�ַ���

        private GameObject characterObject; // �´�����GameObject
        private float moveSpeed = 5f; // �ƶ��ٶ�
        private float Speed = 5f;//��ת�ٶ�
        private float cameraOffsetZ = -10f; // ��������ɫ��Z��ƫ��
        private AudioSource moveSound; // ���� AudioSource

        public CharacterGenerator(Vector3 startPosition, float sortingOrder)
        {
            // �� Resources �ļ��м��� Sprite
            Sprite characterSprite = Resources.Load<Sprite>(spritePath); // ȷ��·����ȷ

            // ȷ�� Sprite ���سɹ�
            if (characterSprite != null)
            {
                // ����һ���µ� GameObject
                characterObject = new GameObject("Character");

                // ��� SpriteRenderer ���
                SpriteRenderer spriteRenderer = characterObject.AddComponent<SpriteRenderer>();

                // ���� SpriteRenderer �� sprite ����
                spriteRenderer.sprite = characterSprite;

                // ����ͼ��˳��ȷ����ɫ�ڵ�ͼ֮��
                spriteRenderer.sortingOrder = (int)sortingOrder;

                // ����ɫλ�������ڿɼ���Χ��
                characterObject.transform.position = startPosition;

                Debug.Log("����ͼƬ���سɹ���������Ϊ GameObject��");
            }
            else
            {
                Debug.LogError("δ�ܼ�������ͼƬ������ļ�����·����");
            }
        }

        public void AddAudioSource()
        {
            // ȷ����ɫ�������
            if (characterObject != null)
            {
                // ��� AudioSource ���
                moveSound = characterObject.AddComponent<AudioSource>();

                // �� Resources �м�����Ч�ļ�
                AudioClip moveClip = Resources.Load<AudioClip>("�ƶ�"); // ȷ���ļ�����ȷ

                // ȷ����Ч�ļ����سɹ�
                if (moveClip != null)
                {
                    // ������Ч�ļ�
                    moveSound.clip = moveClip;
                    moveSound.loop = false; // ����Ϊ��ѭ������

                    Debug.Log("��Ч����ѳɹ���ӵ���ɫ��");
                }
                else
                {
                    Debug.LogError("δ�ܼ�����Ч�ļ�������ļ�����·����");
                }
            }
            else
            {
                Debug.LogError("��ɫ���󲻴��ڣ��޷���� AudioSource �����");
            }
        }

        public void MoveCharacter()
        {
            if (characterObject != null)
            {
                // ��ǽ�ɫ�Ƿ����ƶ�
                bool isMoving = false;

                // ��鰴�����ƶ�
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

                // ������Ч
                if (isMoving && moveSound != null && !moveSound.isPlaying)
                {
                    moveSound.Play(); // ������Ч
                }
                else if (!isMoving && moveSound != null && moveSound.isPlaying)
                {
                    moveSound.Stop(); // ֹͣ��Ч
                }

                // ��ⰴ�� Shift ������
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    moveSpeed = 15f; // ����Ϊ����ٶ�
                }
                else
                {
                    moveSpeed = 5f; // �ָ�ΪĬ���ٶ�
                }
            }
            characterObject.transform.position = new Vector3(Mathf.Clamp(characterObject.transform.position.x, -4, 93), Mathf.Clamp(characterObject.transform.position.y, -4, 93), 0);

        }

        public void HandleRotation()
        {
            // �����ɫ��ת
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


        // ��������淽��
        public void FollowCharacter()
        {
            if (characterObject != null && mainCamera != null)
            {
                // ������������ɫ
                mainCamera.transform.position = new Vector3(characterObject.transform.position.x, characterObject.transform.position.y, cameraOffsetZ);
            }
            else
            {
                Debug.LogError("��������ɫ����δ��ȷ��ʼ��");
            }
        }

        // ���ؽ�ɫ����
        public GameObject GetCharacterObject()
        {
            return characterObject;
        }
    }
}

