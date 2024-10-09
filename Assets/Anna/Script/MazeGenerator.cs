using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject wallPrefab;
    private int[,] maze;

    void Start()
    {
        GenerateMaze();
        DrawMaze();
    }

    void GenerateMaze()
    {
        maze = new int[width, height];
        // Inisialisasi semua dinding
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = 1; // 1 untuk dinding
            }
        }
        // Algoritma pembangkitan maze (Recursive Backtracking)
        CreatePath(1, 1);
    }

    void CreatePath(int x, int y)
    {
        // Atur jalur di sini
        maze[x, y] = 0; // 0 untuk jalur

        // Arah gerakan acak
        int[] directions = { 0, 1, 2, 3 }; // 0: atas, 1: kanan, 2: bawah, 3: kiri
        directions = ShuffleArray(directions); // Acak arah

        foreach (int direction in directions)
        {
            int nx = x, ny = y;
            switch (direction)
            {
                case 0: ny -= 2; break; // Gerak ke atas
                case 1: nx += 2; break; // Gerak ke kanan
                case 2: ny += 2; break; // Gerak ke bawah
                case 3: nx -= 2; break; // Gerak ke kiri
            }

            if (IsInBounds(nx, ny) && maze[nx, ny] == 1)
            {
                maze[nx - (nx - x) / 2, ny - (ny - y) / 2] = 0; // Hapus dinding antara
                CreatePath(nx, ny); // Rekursi
            }
        }
    }

    bool IsInBounds(int x, int y)
    {
        return x > 0 && x < width - 1 && y > 0 && y < height - 1;
    }

    // Fungsi untuk mengacak array
    int[] ShuffleArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int rand = Random.Range(0, array.Length);
            int temp = array[i];
            array[i] = array[rand];
            array[rand] = temp;
        }
        return array;
    }

    void DrawMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (maze[x, y] == 1)
                {
                    // Spawn dinding di posisi (x, y)
                    Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }
}
