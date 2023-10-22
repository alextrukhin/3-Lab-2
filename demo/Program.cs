using System;
using System.Collections;
using ClassLibrary;
using Tree;

namespace demo_3lab2
{
    public class Program
    {
        static public void InOrder<T>(BinaryTreeNode<T>? current) where T : IComparable<T>
        {
            if (current == null)
            {
                return;
            }
            InOrder(current?.Left);
            Console.WriteLine(current!.Data);
            InOrder(current?.Right);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Generic collection:");
            List<Account> AccountGenericList = new List<Account>();
            AccountGenericList.Add(new Account(1, 25));
            AccountGenericList.Add(new Account(25, 0.5));
            AccountGenericList.Add(new Account(345, 314));
            AccountGenericList.Add(new Account(9, 84));
            AccountGenericList.FirstOrDefault(s => s.OwnerCode == 25)?.TopUp(100);
            AccountGenericList.Remove(AccountGenericList.FirstOrDefault(s => s.OwnerCode == 1));
            Console.WriteLine($"Found account: {AccountGenericList.FirstOrDefault(s => s.OwnerCode == 345)}");
            foreach (Account Account in AccountGenericList)
            {
                Console.WriteLine(Account);
            }

            Console.WriteLine();

            Console.WriteLine("Non-generic collection:");
            ArrayList AccountList = new ArrayList();
            AccountList.Add(new Account(1, 25));
            AccountList.Add(new Account(25, 0.5));
            AccountList.Add(new Account(345, 314));
            AccountList.Add(new Account(9, 84));
            AccountList.OfType<Account>().FirstOrDefault(s => s.OwnerCode == 25)?.Withdraw(100);
            AccountList.Remove(AccountList.OfType<Account>().FirstOrDefault(s => s.OwnerCode == 1));
            Console.WriteLine($"Found account: {AccountList.OfType<Account>().FirstOrDefault(s => s.OwnerCode == 345)}");
            foreach (Account Account in AccountList)
            {
                Console.WriteLine(Account);
            }

            Console.WriteLine();

            Console.WriteLine("Simple array:");
            Account[] AccountArray = new Account[4];
            AccountArray[0] = new Account(1, 25);
            AccountArray[1] = new Account(25, 0.5);
            AccountArray[2] = new Account(345, 314);
            AccountArray[3] = new Account(9, 84);
            AccountArray[0].TransferTo(100, AccountArray[2]);
            AccountArray[1] = null;
            Console.WriteLine($"Found account: {Array.Find(AccountArray, s => s != null && s.OwnerCode == 345)}");
            foreach (Account Account in AccountArray)
            {
                if (Account != null)
                {
                    Console.WriteLine(Account);
                }
            }

            Console.WriteLine();

            Console.WriteLine("Binary tree foreach (enumerator):");
            BinaryTree<Account> BinaryTree = new();
            BinaryTree.Insert(new Account(1, 25));
            BinaryTree.Insert(new Account(2, 0.5));
            BinaryTree.Insert(new Account(4, 314));
            BinaryTree.Insert(new Account(3, 84));
            foreach (Account Account in BinaryTree)
            {
                if (Account != null)
                {
                    Console.WriteLine(Account);
                }
            }

            Console.WriteLine();

            Console.WriteLine("Binary tree inOrder:");
            InOrder(BinaryTree.Root);
        }
    }
}