string equation = Console.ReadLine();
Stack<string> stack_brackets = new Stack<string>();

for (int i = 0; i < equation.Length; i++) {
    if (equation[i] == '(' || equation[i] == '{' || equation[i] == '[') {
        stack_brackets.Push(equation[i].ToString());
    } else if (equation[i] == ')' || equation[i] == '}' || equation[i] == ']') {   
        if (stack_brackets.Count == 0) {
            Console.WriteLine("NO");
            return;
        }
        if (equation[i] == ')' && stack_brackets.Pop() != "(") {
            Console.WriteLine("NO");
            return;
        } else if (equation[i] == '}' && stack_brackets.Pop() != "{") {
            Console.WriteLine("NO");
            return;
        } else if (equation[i] == ']' && stack_brackets.Pop() != "[") {
            Console.WriteLine("NO");
            return;
        }
    }
}

if (stack_brackets.Count == 0) {
    Console.WriteLine("YES");
} else {
    Console.WriteLine("NO");
}