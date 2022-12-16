// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
void MoveToBottom(int[] array, int toMove)
{
    
    int left = 0;
    int right = array.Length - 1;

    while (left <= right)
    {
        if (array[left] != toMove)
        {
            left++;
        }
        else if (array[right] == toMove)
        {
            right--;
        }
        else
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
            left++;
            right--;
        }
    }
}

var array = new int[] {2, 1, 2, 2, 2, 3, 4, 2};
var toMove = 2;
MoveToBottom(array,toMove);
Console.WriteLine(string.Join(", ", array));

