string[] str_nums = Console.ReadLine().Split(' ');
Stack<float> stack = new Stack<float>();

foreach (var item in str_nums) {
    if (item == "+" || item == "-" || item == "*" || item == "/") { 
        if (stack.Count < 2) {
            Console.WriteLine("Error: not enough operands");
            return;
        }
        float num1 = stack.Pop();
        float num2 = stack.Pop();
        if (num1 == 0) {
            Console.WriteLine("Error: division by zero");
            return;
        }
        switch (item) {
            case "+":
                stack.Push(num1 + num2);
                break;
            case "-":
                stack.Push(num2 - num1);
                break;
            case "*":
                stack.Push(num1 * num2);
                break;
            case "/":
                stack.Push(num2 / num1);
                break;
        }
    } else {
        stack.Push(float.Parse(item));
    }
}

if (stack.Count != 1) {
    Console.WriteLine("Error: not enough operands");
} else {
    Console.WriteLine(stack.Pop());
}