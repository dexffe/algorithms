using System.Collections;
ArrayList resStr = new ArrayList();
for (int j = 0; j < 100; j++) {
    string localStringResult = "";
    string[] elemOfString = Console.ReadLine().Split();
    if (elemOfString.Length == 1) {
        break;
    }
    for (int i = 0; i < elemOfString.Length; i++) {
        if (int.TryParse(elemOfString[i], out int num)) {
            localStringResult += resStr[num-1];
        } else {
            localStringResult += elemOfString[i];
        }
    }
    localStringResult += elemOfString[0].Replace("WATER", "TW").Replace("DUST", "TD").Replace("FIRE", "RF").Replace("MIX", "XM");
    resStr.Add(localStringResult);
}
string result = resStr[resStr.Count-1].ToString().Replace("WATER", "WT").Replace("DUST", "DT").Replace("FIRE", "FR").Replace("MIX", "MX");
Console.WriteLine(result);