string Multiplication(string equation, int constant) {
    string s = "";
    foreach (var item in equation.Trim().Split()) {
        if (item[item.Length - 1] == 'x') {
            s += $" {int.Parse(item.Substring(0, item.Length - 1)) * constant}x";
        } else {
            s += $" {int.Parse(item) * constant}";
        }
    }
    return s;
}

string function = "+1x";
int countElements = int.Parse(Console.ReadLine());
for (int i = 0; i < countElements; i++) {
    string[] str = Console.ReadLine().Split();
    if (str[0] == "-") {
        if (str[str.Length - 1] != "x") {
            function += $" {int.Parse(str[1]) * -1}";
        } else {
            function += $" -1x";
        }
    } else if (str[0] == "+") {
        if (str[str.Length - 1] != "x") {
            function += $" {int.Parse(str[1])}";
        } else {
            function += $" +1x";
        }
    } else if (str[0] == "*") {
        function = Multiplication(function, int.Parse(str[1]));
    }
}

int result = int.Parse(Console.ReadLine());

int koefX = 0;
int koefConstant = 0;
foreach (string item in function.Trim().Split(" ")) {
    if (item[item.Length - 1] == 'x') {
        koefX += int.Parse(item.Substring(0, item.Length - 1));
    } else {
        koefConstant += int.Parse(item);
    }
}

Console.WriteLine($"x = {((koefConstant*-1) + result)/koefX}");
