string equation = Console.ReadLine();
Stack<string> stack_brackets = new Stack<string>();

for (int i = 0; i < equation.Length; i++) {
    if (equation[i] == '(') {
        stack_brackets.Push("(");
    } else if (equation[i] == ')') {
        if (stack_brackets.Count > 0 && stack_brackets.Peek() == "(") {
            stack_brackets.Pop();
        }
    } else if (equation[i] == '{') {
        stack_brackets.Push("{");
    } else if (equation[i] == '}') {
        if (stack_brackets.Count > 0 && stack_brackets.Peek() == "{") {
            stack_brackets.Pop();
        }
    } else if (equation[i] == '[') {
        stack_brackets.Push("[");
    } else if (equation[i] == ']') {
        if (stack_brackets.Count > 0 && stack_brackets.Peek() == "[") {
            stack_brackets.Pop();
        }
    }
}

if (stack_brackets.Count == 0) {
    Console.WriteLine("YES");
} else {
    Console.WriteLine("NO");
}