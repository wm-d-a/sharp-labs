namespace Lab10
{
    interface INameAndCopy
    {
        string Name { get; set;}
        object DeepCopy(); 
    }
}