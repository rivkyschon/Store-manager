namespace DalApi;

public class ItemNotFound:Exception
{
   public ItemNotFound(string message) : base(message) { }
}
public class DuplicateValue:Exception
{
    public DuplicateValue(string message) : base(message) {}
}
public class nullValueException : Exception
{
    public override string Message =>
                   "null value object";
}

    public class XMLFileNullExeption : Exception
{
    public override string Message =>
                    "XML file is empty";

}