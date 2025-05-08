using System;
using System.Threading;

public delegate void HorseFinishedHandler(string name, TimeSpan time);

public class Horse {
    public string Name { get; private set; }

    private int _finishLine;
    private Random _rnd = new Random();

    public event HorseFinishedHandler Finished;

    public Horse(string name, int finishLine) {
        Name = name;
        _finishLine = finishLine;
    }

    public void StartRace() {
        int position = 0;
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        while (position < _finishLine) {
            int speed = _rnd.Next(5, 15);
            position += speed;
            Thread.Sleep(200); 
        }

        watch.Stop();
        Finished?.Invoke(Name, watch.Elapsed); 
    }
}

class Program {
    static bool raceOver = false;

    static void Main() {
        const int finishLine = 1000;

        Console.WriteLine("🏁 Гонка началась!\n");

        Horse horse1 = new Horse("Молния", finishLine);
        Horse horse2 = new Horse("Стремительный", finishLine);
        Horse horse3 = new Horse("Буревестник", finishLine);

        horse1.Finished += OnHorseFinished;
        horse2.Finished += OnHorseFinished;
        horse3.Finished += OnHorseFinished;

        Thread t1 = new Thread(horse1.StartRace);
        Thread t2 = new Thread(horse2.StartRace);
        Thread t3 = new Thread(horse3.StartRace);

        t1.Start();
        t2.Start();
        t3.Start();

        Console.WriteLine("Лошади на старте...\n");
    }

    static void OnHorseFinished(string name, TimeSpan time) {
        if (!raceOver) {
            Console.WriteLine($"\n🏆 Победитель: {name}!");
            Console.WriteLine($"Время: {time.TotalSeconds:F2} секунд.");
            raceOver = true;
        }
    }
}
