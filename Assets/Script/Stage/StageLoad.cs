using UnityEngine;
using System.Collections;

public class StageLoad : MonoBehaviour {
    public GameObject player;
    public GameObject stair;

    public GameObject wallPrefab;
    public GameObject mobPrefab;
    public GameObject doorPrefab;
    public GameObject barrelPrefab;
    public GameObject torchPrefab;
    public GameObject meatPrefab;
    public GameObject keyPrefab;

    public GameObject wallGroup;
    public GameObject mobGroup;
    public GameObject doorGroup;
    public GameObject barrelGroup;
    public GameObject torchGroup;
    public GameObject meatGroup;
    public GameObject keyGroup;

    public GameObject doorAndLeverGroup;

    // [HideInInspector]
    public int targetStage;

    int width = 20;
    int height = 20;
    int stagesSize = 3;

    float cellPixelBaseZ = -10f;
    float cellPixelBaseX = -9f;
    float cellPixelWidth = 1f;
    float cellPixelHeight = 1f;

    int currentStage;

    string[/*stagesSize*/, /*height*/] cells = {
        // 0F
        {
            "####################",
            "###########........#",
            "###########.H..M...#",
            "#TH.M..M..D........#",
            "#...#######.......H#",
            "#...###########.####",
            "#B##HB....BK#H....H#",
            "#B##BB...MBB#......#",
            "#B##.M......#......#",
            "#BH#........#......#",
            "#BB#........#####..#",
            "#BB#BBM.....##S##..#",
            "#HB#HB......#...#..#",
            "#BB###.####D#...#..#",
            "#.......H#..H...#..#",
            "#......M.########..#",
            "#........#......H..#",
            "##########...#######",
            "#P...........#######",
            "####################"
        },

        // 1F
        {
            "####################",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "####################"
        },

        // 2F
        {
            "####################",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "#..................#",
            "####################"
        }
    };

	void Start() {
        targetStage = 0;
        currentStage = -1;
	}

    void Update() {
        if (targetStage == currentStage) {
            return;
        }
        ClearStage();
        LoadStage(targetStage);
        currentStage = targetStage;

    }

    void ClearStage() {
        ClearGroup(wallGroup);
        ClearGroup(mobGroup);
        ClearGroup(doorGroup);
        ClearGroup(barrelGroup);
        ClearGroup(torchGroup);
        ClearGroup(meatGroup);
        ClearGroup(keyGroup);

        ClearGroup(doorAndLeverGroup);
    }

    void ClearGroup(GameObject group) {
        foreach (Transform element in group.transform) {
            Destroy(element.gameObject);
        }
    }

    void LoadStage(int stage) {
        for (int x = 0; x < height; ++x) {
            string row = cells[stage, x];
            for (int z = 0; z < width; ++z) {
                char cell = row[z];
                switch (cell) {
                    case '.': break;
                    case 'P': SettleObject(z, x, player); break;
                    case 'S': SettleObject(z, x, stair); break;
                    case '#': SettleGroupObject(z, x, wallPrefab, wallGroup); break;
                    case 'M': SettleGroupObject(z, x, mobPrefab, mobGroup); break;
                    case 'D': SettleGroupObject(z, x, doorPrefab, doorGroup); break;
                    case 'B': SettleGroupObject(z, x, barrelPrefab, barrelGroup); break;
                    case 'T': SettleGroupObject(z, x, torchPrefab, torchGroup); break;
                    case 'K': SettleGroupObject(z, x, keyPrefab, keyGroup); break;
                    case 'H': SettleGroupObject(z, x, meatPrefab, meatGroup); break;
                    default: Debug.LogError("LoadStage: unknown cell type: [" + cell + "]"); break;
                }
            }
        }
    }

    void SettleObject(int z, int x, GameObject obj) {
        float posZ = cellPixelBaseZ + cellPixelWidth * (float)z;
        float posX = cellPixelBaseX + cellPixelHeight * (float)x;
        obj.transform.position = new Vector3(posX, obj.transform.position.y, posZ);
    }

    void SettleGroupObject(int z, int x, GameObject prefab, GameObject group) {
        GameObject obj = (GameObject)Instantiate(prefab);
        SettleObject(z, x, obj);
        obj.transform.parent = group.transform;
    }
}
