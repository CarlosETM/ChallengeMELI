using System;
using System.Collections.Generic;

public class RequestSatellite
{   
     
    public List<Satellite1> satellites { get; set; }
}
public class Satellite1
{
    public string name { get; set; }
    public int distance { get; set; }
    public List<string> message { get; set; }

}
