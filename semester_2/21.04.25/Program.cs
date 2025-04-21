using System.Collections.Immutable;

string filePath = "file.txt";

string output_file = "output_file.txt";

// Good Code 
// string[] lines = File.ReadAllLines(filePath);
// for (int i = 0; i < lines.Length; i++) {
//     string line = lines[i];
//     string new_line = line;
//     for (int j = 0; j < line.Length; j++) {
//         char item = line[j];
//         if (!char.IsDigit(item)) {
//             new_line = new_line.Replace(new_line[j].ToString(), "*");
//         }
//     }
//     foreach (string item in new_line.Split('*')) {
//         if (item != "" && int.Parse(item) % 2 != 0) {
//             File.AppendAllText(output_file, line + "\n");
//             break;
//         }
//     }
// }


// Bad Code
string[] lines = File.ReadAllLines(filePath);
for (int i = 0; i < lines.Length; i++) {
    string line = lines[i];
    string number = "";
    foreach (char item in line) {
        if (char.IsDigit(item)) {
            number += item;
        } else {
            if (number != "" && int.Parse(number) % 2 != 0) {
                File.AppendAllText(output_file, line + "\n");
                break;
            }
        }
    }
}