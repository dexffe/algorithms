using System;
using System.Runtime.InteropServices;

public unsafe struct Student
{
    public int Id;
    public string Fio;
    public Student* Left;
    public Student* Right;

    public Student(int id, string fio)
    {
        Id = id;
        Fio = fio;
        Left = null;
        Right = null;
    }
}

public unsafe class BinaryTree
{
    public Student* Root;

    public void Insert(Student student)
    {
        Root = InsertRec(Root, student);
    }

    private unsafe Student* InsertRec(Student* root, Student student)
    {
        if (root == null)
        {
            Student* newRoot = (Student*)Marshal.AllocHGlobal(sizeof(Student));
            *newRoot = student;
            newRoot->Left = null;
            newRoot->Right = null;
            return newRoot;
        }
        if (student.Id < root->Id)
        {
            root->Left = InsertRec(root->Left, student);
        }
        else if (student.Id > root->Id)
        {
            root->Right = InsertRec(root->Right, student);
        }
        return root;
    }
    
    public void PrintInOrder(Student* root)
    {
        if (root == null) return;
        
        PrintInOrder(root->Left);
        PrintInOrder(root->Right);
        Console.WriteLine($"ID: {root->Id}, Name: {root->Fio}");
    }

    public void FreeTree(Student* root)
    {
        if (root == null) return;

        FreeTree(root->Left);
        FreeTree(root->Right);
        Marshal.FreeHGlobal((IntPtr)root);
    }
}


public unsafe class Program
{
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        Student student1 = new Student(1, "Ivan Ivanov");
        Student student2 = new Student(2, "Petr Petrov");
        Student student3 = new Student(3, "Sidor Sidorov");
        Student student4 = new Student(4, "Vasiliy Vasilev");
        Student student5 = new Student(5, "Fedor Fedorov");

        tree.Insert(student1);
        tree.Insert(student3);
        tree.Insert(student2);
        tree.Insert(student4);
        tree.Insert(student5);

        tree.PrintInOrder(tree.Root);

        tree.FreeTree(tree.Root);

    }
}