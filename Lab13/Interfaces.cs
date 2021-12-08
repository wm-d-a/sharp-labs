namespace Lab13
{
    interface INameAndCopy
    {
        string Name { get; set;}
        object DeepCopy(); 
    }
}