string data1 = Console.ReadLine();
string data2 = Console.ReadLine(); 

int year1 = int.Parse(data1.Split('.')[2]);
int month1 = int.Parse(data1.Split('.')[1]);
int day1 = int.Parse(data1.Split('.')[0]);

int year2 = int.Parse(data2.Split('.')[2]);
int month2 = int.Parse(data2.Split('.')[1]);
int day2 = int.Parse(data2.Split('.')[0]);

DateTime d1 = new DateTime(year1, month1, day1);
DateTime d2 = new DateTime(year2, month2, day2);

TimeSpan t = d2 - d1;
double CountOfDays = t.TotalDays;

int P = int.Parse(Console.ReadLine());
int Otvet = P;
for (int i = 0; i < CountOfDays; i++) {
    P += 1;
    Otvet += P;
}

Console.WriteLine(Otvet);
