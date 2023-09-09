using System;

class Sudoku
{
    static int[,] sudoku = new int[9, 9]
    {
        {5, 3, 0, 0, 7, 0, 0, 0, 0},
        {6, 0, 0, 1, 9, 5, 0, 0, 0},
        {0, 9, 8, 0, 0, 0, 0, 6, 0},
        {8, 0, 0, 0, 6, 0, 0, 0, 3},
        {4, 0, 0, 8, 0, 3, 0, 0, 1},
        {7, 0, 0, 0, 2, 0, 0, 0, 6},
        {0, 6, 0, 0, 0, 0, 2, 8, 0},
        {0, 0, 0, 4, 1, 9, 0, 0, 5},
        {0, 0, 0, 0, 8, 0, 0, 7, 9}
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al juego de Sudoku.");
        PrintSudoku();

        while (!IsSudokuSolved())
        {
            Console.WriteLine("Ingresa fila (1-9), columna (1-9) y valor (1-9) separados por espacios (ejemplo: 3 5 7):");
            string[] input = Console.ReadLine().Split(' ');

            if (input.Length != 3)
            {
                Console.WriteLine("Entrada no válida. Debe ingresar tres números separados por espacios.");
                continue;
            }

            if (int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col) && int.TryParse(input[2], out int value))
            {
                if (IsValidMove(row - 1, col - 1, value))
                {
                    sudoku[row - 1, col - 1] = value;
                    PrintSudoku();
                }
                else
                {
                    Console.WriteLine("Movimiento no válido. Inténtalo de nuevo.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Debe ingresar números enteros.");
            }
        }

        Console.WriteLine("¡Felicidades! Has resuelto el Sudoku.");
    }

    static void PrintSudoku()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                Console.Write(sudoku[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    static bool IsSudokuSolved()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku[row, col] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    static bool IsValidMove(int row, int col, int value)
    {
        // Verifica si la celda ya contiene un número.
        if (sudoku[row, col] != 0)
        {
            return false;
        }

        // Implementa la lógica para verificar si un movimiento es válido.
        // Puedes usar algoritmos de validación de Sudoku disponibles en línea.
        // En este ejemplo, simplemente verificamos si el valor ya existe en la fila, columna y cuadrante.

        for (int i = 0; i < 9; i++)
        {
            if (sudoku[row, i] == value || sudoku[i, col] == value || sudoku[row - row % 3 + i / 3, col - col % 3 + i % 3] == value)
            {
                return false;
            }
        }

        return true;
    }
}
