using System;

public class RequestSatelites
{   
     
    public List<Satellite> satellites { get; set; }
}
public class Satellite
{
    public string name { get; set; }
    public int distance { get; set; }
    public List<string> message { get; set; }

}
