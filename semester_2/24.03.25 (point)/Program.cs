using System;

class Point {
    public int x, y;
    public Point(int X, int Y) {
        this.x = X + new Random().Next(-5, 5);
        this.y = Y + new Random().Next(-5, 5);
    }
}


class Program {
    static void Main(string[] args) {
        //* static field
        int[] top_r = [2, 15];
        int[] top_l = [-10, 15];
        int[] bottom_r = [2, -40];
        int[] bottom_l = [-10, -40];

        //* player coords
        int X = top_l[0]/2 + top_r[0]/2;
        int Y = top_l[1]/2 + bottom_l[1]/2;

        bool inField = true;
        while (inField) {
            Point point = new Point(X, Y);
            X = point.x;
            Y = point.y;
            if (top_l[0] <= point.x && point.x <= top_r[0] && bottom_r[1] <= point.y && point.y <= top_r[1]) {
                Console.WriteLine($"Успешный ход, координаты: {X} {Y}");
            } else {
                Console.WriteLine("Выход за границы поля, конец...");
                inField = false;
            }
        }

    }
}