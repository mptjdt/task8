using System; // 用于 Action 和事件定义
using UnityEngine;
using static UnityEngine.Object;
using static 墨心.LocalStorage;
using static 墨心.Task8.LocalStorage;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace 墨心.Task8 {
    public class Event {
        public static event Action<Vector2, float> 当角色坐标更新;
        public static event Action<I地块> 当地块采光;
        public static event Action<I地块> 当地块采集成功;
        public static event Action<I地块> 当建筑受伤;
        public static event Action<I地块> 当地块建筑被毁;
        public static event Action<I地块> 当建筑掉落;
        public static event Action 当玩家死亡;
        public static event Action 当笔记背包状态更新;
        public static void 角色坐标更新(Vector2 position, float rotation) {
            当角色坐标更新?.Invoke(position, rotation);//人物移动
        }
        public static void 地块矿石采光(I地块 X) {
            当地块采光?.Invoke(X);
        }
        public static void 地块采集成功(I地块 X) {
            当地块采集成功?.Invoke(X);
        }
        public static void 建筑受伤(I地块 X) {
            当建筑受伤?.Invoke(X);
        }
        public static void 地块建筑被毁(I地块 X) {
            当地块建筑被毁?.Invoke(X);
        }
        public static void 建筑掉落(I地块 X) {
            当建筑掉落?.Invoke(X);
        }
        public static void 玩家死亡() {
            当玩家死亡?.Invoke();
        }
        public static void 笔记背包状态更新() {
            当笔记背包状态更新?.Invoke();
        }
        static Event() {
            当角色坐标更新 += (X, Y) => {
                前台世界.玩家.transform.position = X;
                前台世界.玩家.transform.rotation = Quaternion.Euler(0, 0, Y);
            };
            当地块采集成功 += (X) => {
                if (X.矿石层 != null) {
                    后台世界.Player.背包.添加物品(new 后台物品类() { 名称 = X.矿石层.类型.ToString(), 数量 = 1,体积 = 2,重量 = 2 });
                }
                UI.更新背包显示(后台世界.Player.背包);
            };
            当地块采光 += (X) => {
                if (前台世界.所有矿石.TryGetValue(X.坐标, out GameObject A)) {
                    前台世界.所有矿石.Remove(X.坐标);
                    Destroy(A);
                    Print($"地块 {X.坐标.x}-{X.坐标.y} 采光！");
                }
            };
            当建筑受伤 += (X) => {
                if (X.建筑层 != null) {
                    前台世界.所有建筑.TryGetValue(X.坐标, out GameObject A);
                    A.Tremble();
                    后台世界.Player.背包.添加物品(new 后台物品类() { 名称 = X.建筑层.类型.ToString(), 数量 = 2,体积 = 2,重量 = 1});
                }
                UI.更新背包显示(后台世界.Player.背包);
            };
            当地块建筑被毁 += (X) => {
                if (前台世界.所有建筑.TryGetValue(X.坐标, out GameObject A)) {
                    前台世界.所有建筑.Remove(X.坐标);
                    Destroy(A);
                    Print($"地块建筑 {X.坐标.x}-{X.坐标.y} 被毁！");
                }
            };
            当建筑掉落 += (X) => {
                foreach (var A in X.悬浮层.道具们) {
                    Print($"物品: {A.Key}, 数量: {A.Value}");
                    后台世界.Player.背包.添加物品(new 后台物品类() {
                        名称 = A.Key,
                        数量 = A.Value,
                        体积=1,
                        重量=1
                    });
                }
                X.悬浮层 = null;
                UI.更新背包显示(后台世界.Player.背包);
            };
            当玩家死亡 += () => {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            };
            当笔记背包状态更新 += () => {
                UI.开关背包(笔记.背包是否打开);
            };
        }
    }
}