using System.Collections.Generic;
using RMC.BestPractices.Shared;
using UnityEngine;

namespace RMC.BestPractices.CodingChallenges.SinglyLinkedList
{
    //Definition for singly-linked list.
    //Do not edit
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
 
    
	/// <summary>
	/// https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/
	/// </summary>
	public class Challenge_SinglyLinkedList : BaseDemo
	{
		protected override void Start()
		{
			// Must call base
			base.Start();
            
            // Sample linked list
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
			
            //
            Debug.Log("LinkedListForward() --------------");
			LinkedListForward(head);
            
            //
            Debug.Log("LinkedListBackward() --------------");
            LinkedListBackward(head);
		}

		private void LinkedListForward(ListNode listNode)
		{
            ListNode currentNode = listNode;
            while (currentNode != null)
            {
                Debug.Log("Val: " + currentNode.val);
                currentNode = currentNode.next;
            }
		}
        
		private void LinkedListBackward(ListNode head)
		{
			if (head == null) return;

			//1. Build new list in reverse order
			List<ListNode> visitedNodes = new List<ListNode>();
			ListNode currentNode = head;
			while (currentNode != null)
			{
				visitedNodes.Add(currentNode);
				currentNode = currentNode.next;
			}

			//2. Use new list for output
			for (int i = visitedNodes.Count - 1; i >= 0; i--)
			{
				Debug.Log("Val: " + visitedNodes[i].val);
			}
		}
	}
}